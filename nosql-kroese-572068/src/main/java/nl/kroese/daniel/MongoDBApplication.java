package nl.kroese.daniel;

import com.mongodb.BasicDBList;
import com.mongodb.BasicDBObject;
import com.mongodb.DBObject;
import com.mongodb.client.FindIterable;
import com.mongodb.client.MongoCollection;
import com.mongodb.client.MongoCursor;
import com.mongodb.client.MongoDatabase;
import com.mongodb.client.model.Collation;
import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.Label;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;
import org.bson.Document;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import static com.mongodb.client.model.Filters.eq;

public class MongoDBApplication extends Application {

    @Override
    public void start(Stage primaryStage) {
        primaryStage.setTitle("Afgestudeerden Haarlem");
        VBox group = new VBox();
        group.setSpacing(1.0);

        MongoDatabase database = Database.getDatabase();
        MongoCollection<Document> collection = database.getCollection("hbo_gediplomeerden_2019");

        FindIterable<Document> iterable = collection
                .find(eq("GEMEENTENAAM", "Haarlem"))
                .sort(new BasicDBObject("2018", -1))
                .limit(5);
        for (Document document : iterable) {
            List<Map.Entry<String, Object>> set = new ArrayList<>(document.entrySet());

            Label label = new Label(set.get(9).getValue().toString() + " geslaagd: " + set.get(17).getValue().toString());
            group.getChildren().add(label);
        }

        Scene scene = new Scene(group, 500, 400);
        primaryStage.setScene(scene);

        primaryStage.show();
    }

    public static void main(String[] args) {
        MongoDBApplication.launch(args);
    }

    public void loadCSV() {
        MongoDatabase database = Database.getDatabase();
        String csvFile = "/Users/danielkroese/Desktop/05-gediplomeerden-hbo-2019.csv";
        BufferedReader reader = null;
        String line;
        String splitChar = ";";
        String[] columns;

        try {

            reader = new BufferedReader(new FileReader(csvFile));
            columns = reader.readLine().split(splitChar);
            while ((line = reader.readLine()) != null) {

                // use comma as separator
                String[] documentLine = line.split(splitChar);

                Document document = new Document();
                for (int i = 1; i < columns.length; i++) {

                    // parse as ints for graduated amount
                    if (columns[i].equals("2018") ||
                            columns[i].equals("2017") ||
                            columns[i].equals("2016") ||
                            columns[i].equals("2015") ||
                            columns[i].equals("2014")) {
                        document.append(columns[i], Integer.parseInt(documentLine[i]));
                    } else
                        document.append(columns[i], documentLine[i]);
                }
                MongoCollection<Document> collection = database.getCollection("hbo_gediplomeerden_2019");
                collection.insertOne(document);
                System.out.println("Opleiding " + documentLine[9] + ", geslaagd: " + documentLine[17]);

            }

        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            if (reader != null) {
                try {
                    reader.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    }
}