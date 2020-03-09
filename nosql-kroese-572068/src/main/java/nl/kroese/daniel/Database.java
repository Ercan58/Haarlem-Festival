package nl.kroese.daniel;

import com.mongodb.MongoClient;
import com.mongodb.MongoClientURI;
import com.mongodb.client.MongoCollection;
import com.mongodb.client.MongoDatabase;
import org.bson.Document;

public class Database {
    private MongoClientURI uri = new MongoClientURI(
            "mongodb+srv://mdbUser:oyB2dXWT267VRAc1@cluster0-upapv.azure.mongodb.net/test?retryWrites=true&w=majority");
    private static MongoDatabase database = null;

    private Database() {
        connect();
    }

    public static MongoDatabase getDatabase() {
        if (database == null)
            new Database();

        return database;
    }

    private void connect() {
        MongoClient mongoClient = new MongoClient(uri);
        database = mongoClient.getDatabase("inholland");
    }

    public void insertDocument(Document document) throws Exception{
        if (database != null){
            MongoCollection<Document> collection = database.getCollection("hbo_gediplomeerden_2019");
            collection.insertOne(document);
        } else {
            throw new Exception("No database set to insert to.");
        }
    }
}
