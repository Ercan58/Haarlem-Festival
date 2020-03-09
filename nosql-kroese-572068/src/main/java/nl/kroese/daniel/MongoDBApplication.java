package nl.kroese.daniel;

import com.mongodb.client.FindIterable;
import com.mongodb.client.MongoCollection;
import com.mongodb.client.MongoCursor;
import com.mongodb.client.MongoDatabase;
import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.chart.BarChart;
import javafx.scene.chart.CategoryAxis;
import javafx.scene.chart.NumberAxis;
import javafx.scene.chart.XYChart;
import javafx.scene.chart.XYChart.Series;
import javafx.stage.Stage;
import org.bson.Document;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;

public class MongoDBApplication extends Application {

    @Override
    public void start(Stage primaryStage) {
        primaryStage.setTitle("Bar Chart Sample");
        final CategoryAxis xAxis = new CategoryAxis();
        final NumberAxis yAxis = new NumberAxis();
        final BarChart<String, Number> chart =
                new BarChart<>(xAxis, yAxis);
        MongoDatabase database = Database.getDatabase();
        MongoCollection<Document> collection = database.getCollection("hbo_gediplomeerden_2019");
        FindIterable<Document> iterable = collection.find();
        MongoCursor<Document> cursor = iterable.iterator();

        // Get the first object from the cursor
        Document obj = cursor.next();

        // Get all the dates from the entry set but exclude the first 5 (_id, province, country, lat, long)
        List<Map.Entry<String, Object>> set = obj.entrySet().stream().skip(5).collect(Collectors.toList());

        // Create a chart series to fill with your data
        Series series = new Series();

        // Loop trough the date's and add them to the series
        for (Map.Entry<String, Object> entry : set) {
            series.getData().add(new XYChart.Data<>(entry.getKey(), Integer.parseInt(entry.getValue().toString())));
        }

        // Append the series to the chart
        chart.getData().add(series);
        chart.setTitle("Confirmed Corona Cases");
        xAxis.setLabel("Date");
        yAxis.setLabel("Cases");

        Scene scene = new Scene(chart, 500, 400);
        primaryStage.setScene(scene);

        primaryStage.show();
    }

    public static void main(String[] args) {
        MongoDBApplication.launch(args);
    }

    public void loadCSV(){
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
                for (int i=1; i < columns.length; i++){
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