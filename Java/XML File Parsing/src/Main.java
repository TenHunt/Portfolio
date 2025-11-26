import javax.xml.XMLConstants;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.DocumentBuilder;
import org.w3c.dom.Document;
import org.w3c.dom.NodeList;
import org.w3c.dom.Node;
import org.w3c.dom.Element;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.Locale;


public class Main {
    public static void main(String[] args) {
        try {
            final String FILENAME = args[0]; // Get the XML file path argument, locally or on web server
            System.out.println("Input file path: " + args[0]);

            if (FILENAME.isEmpty()) { // Checks if the file path argument is empty
                System.err.println("Please enter a file name.");
                return;
            }
            File xmlFile = new File(FILENAME);

            if (!xmlFile.exists()) { // Checks if the file exists
                System.err.println("File " + FILENAME + " does not exist.");
                return;
            }

            // Use original file name but with .out extension instead of .xml
            String fileName = xmlFile.getName();
            int lastDot = fileName.lastIndexOf('.');
            String outFileName = fileName.substring(0, lastDot) + ".out";
            System.out.println("Output file name: " + outFileName);

            // Ensure proper currency formatting for South Africa
            double totalPrice = 0.0;
            Locale southAfrica = Locale.forLanguageTag("en-ZA");
            NumberFormat currencyFormatter = NumberFormat.getCurrencyInstance(southAfrica);
            DecimalFormat df = new DecimalFormat("####0.00");

            // Parse the XML file
            DocumentBuilderFactory dbFactory = DocumentBuilderFactory.newInstance();
            DocumentBuilder dBuilder = dbFactory.newDocumentBuilder();
            Document doc = dBuilder.parse(xmlFile);
            doc.getDocumentElement().normalize();
            dbFactory.setFeature(XMLConstants.FEATURE_SECURE_PROCESSING, true);

            // Get info about the recipe from the root
            Element root = doc.getDocumentElement();
            String rName = root.getAttribute("name"); // Recipe name
            String rCurrency = root.getAttribute("currency"); // Recipe currency
            System.out.println("Recipe name " + rName + " with the currency " + rCurrency);

            // Get all the ingredients from XML
            NodeList nList = doc.getElementsByTagName("ingredient");
            FileWriter writer = new FileWriter(outFileName);

            // First two lines with name and currency
            writer.write("Recipe Name: " + rName + "\n");
            writer.write("Currency: " + rCurrency + "\n");

            // Loop through ingredients and append to file
            for (int i = 0; i < nList.getLength(); i++) {
                Node nNode = nList.item(i);
                Element eElement = (Element) nNode;

                writer.write(eElement.getElementsByTagName("name").item(0).getTextContent());

                String strAmount = eElement.getElementsByTagName("price").item(0).getTextContent();
                strAmount = strAmount.replaceAll("[^\\d.]", "");

                double amount = Double.parseDouble(strAmount);

                if(rCurrency.equals("cents")){ // If price (currency) is in cents, convert to whole currency number
                    double cents = amount;
                    amount = amount / 100;
                    writer.write(" (" + String.format("%.0f", cents) + " cents)\n");
                } else {
                    String formattedAmount = currencyFormatter.format(amount);
                    writer.write(" (" + formattedAmount + ")\n");
                }

                totalPrice += amount;
            }

            // Add final totals at end of file
            writer.write("Total Ingredient Count: " + nList.getLength() + "\n");
            writer.write("Total Price: " + currencyFormatter.format(totalPrice));

            writer.close();

            System.out.println("Done writing to file.");
        } catch (IOException e) {
            System.err.println("Error writing output file: " + e.getMessage() + "\nStack trace: ");
            e.printStackTrace();
        } catch (Exception e) {
           System.err.println("Error: " + e.getMessage() + "\nStack trace: ");
           e.printStackTrace();
        }
    }
}