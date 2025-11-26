// Frequency Distribution for WIM Assessment by Daniël De Jager

import com.opencsv.CSVReader;
import com.opencsv.exceptions.CsvValidationException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class FreqDist {
    public static void main(String[] args) {
        new FreqDist().run();
    }

    public void run() {
        System.out.println("Frequency Distribution for WIM Assessment by Daniël De Jager");

        String filePath = "data.csv";

        // Read the CSV file
        Object[][] cellTower = readFile(filePath);

        // Assign frequencies according to requirements
        assignFreq(cellTower);

        // Finally provide assignment output
        System.out.printf("%-8s %s%n", "Cell ID", "Frequency");
        System.out.println("------------------------");
        for (Object[] objects : cellTower) {
            System.out.printf("%-8s %d%n", objects[0], objects[3]);
        }
    }

    // Reads data from a CSV input file
    private Object[][] readFile(String filePath) {
        List<List<String>> csvData = new ArrayList<>();
        try (CSVReader reader = new CSVReader(new FileReader(filePath))) {
            reader.readNext(); // Grabs the header
            String[] nextLine;
            while ((nextLine = reader.readNext()) != null) {
                List<String> row = new ArrayList<>();
                for(String c : nextLine) row.add(c.trim());
                csvData.add(row);
            }
        } catch (IOException | CsvValidationException e) {
            System.out.println(e.getMessage());
        }

        Object[][] cellTower = new Object[csvData.size()][4]; // Multi-type multi-dimensional array to store cell tower info
        // Iterate through cell towers to get data
        int h = 0;
        for(List<String> row : csvData) {
            cellTower[h][0] = row.get(0).charAt(0); // Gets cell tower ID
            cellTower[h][1] = Integer.parseInt(row.get(1)); // Easting
            cellTower[h][2] = Integer.parseInt(row.get(2)); // Northing
            cellTower[h][3] = 0; // Initialize frequency for later
            //System.out.println(cellTower[h][0].toString() + " " + cellTower[h][1] + " " + cellTower[h][2]);
            h++;
        }

        return cellTower;
    }

    private double calcDist(int firstX, int firstY, int secondX, int secondY) {
        int xDist =  Math.abs(firstX - secondX);
        int yDist =  Math.abs(firstY - secondY);

        return Math.sqrt((xDist*xDist)+(yDist*yDist)); // Use Pythagorean theorem to calculate straight-line distance
    }

    private void assignFreq(Object[][] cellTowers) {
        int[] firstTowerIDs = new int[cellTowers.length];
        int[] furthestTowerIDs = new int[cellTowers.length];
        int[] nearestTowerIDs = new int[cellTowers.length];
        int[] secondNearestTowerIDs = new int[cellTowers.length];
        int[] thirdNearestTowerIDs = new int[cellTowers.length];

        for (int i = 0; i < cellTowers.length; i++) {
            double furthestDist = Double.MIN_VALUE;
            double nearestDist = Double.MAX_VALUE;
            double secondNearestDist = Double.MAX_VALUE;
            double thirdNearestDist = Double.MAX_VALUE;
            int furthestTower = -1;
            int nearestTower = -1;
            int secondNearestTower = -1;
            int thirdNearestTower = -1;
            for (int j = 0; j < cellTowers.length; j++) {
                double distance = calcDist((int)cellTowers[i][1], (int)cellTowers[i][2], (int)cellTowers[j][1], (int)cellTowers[j][2]);
                if (distance > furthestDist) {
                    furthestDist = distance;
                    furthestTower = j;
                }
                if (distance < nearestDist && distance != 0.0) {
                    thirdNearestDist = secondNearestDist;
                    secondNearestDist = nearestDist;
                    nearestDist = distance;
                    thirdNearestTower = secondNearestTower;
                    secondNearestTower = nearestTower;
                    nearestTower = j;
                } else if(distance < secondNearestDist && distance != 0.0) {
                    secondNearestDist = nearestDist;
                    secondNearestTower = nearestTower;
                } else if(distance < thirdNearestDist && distance != 0.0) {
                    thirdNearestDist = secondNearestDist;
                    thirdNearestTower = secondNearestTower;
                }
            }
            firstTowerIDs[i] = i;
            furthestTowerIDs[i] = furthestTower;
            nearestTowerIDs[i] = nearestTower;
            secondNearestTowerIDs[i] = secondNearestTower;
            thirdNearestTowerIDs[i] = thirdNearestTower;
        }

        // Set initial frequencies in a cycle from 110 to 115
        int freq = 109; // Start one below so 110 is included from the start
        for (int i = 0; i < cellTowers.length; i++) {
            freq = (freq == 115) ? 110 : freq + 1;
            cellTowers[i][3] = freq;
        }

        // Furthest towers should have the same frequency
        for(int i = 0; i < cellTowers.length; i++) {
            if(cellTowers[firstTowerIDs[i]][3] != cellTowers[furthestTowerIDs[i]][3]) {
                cellTowers[firstTowerIDs[i]][3] = cellTowers[furthestTowerIDs[i]][3]; // Use same frequency
            }
        }

        int[][] neighborLists = {nearestTowerIDs, secondNearestTowerIDs, thirdNearestTowerIDs};

        for(int[] neighbors : neighborLists) {
            for(int i = 0; i < cellTowers.length; i++) {
                int currFreq = (int) cellTowers[i][3];
                int nearFreq = (int) cellTowers[neighbors[i]][3];

                if(currFreq == nearFreq) {
                    freq = (freq == 115) ? 110 : freq + 1;
                    if(freq == currFreq) {
                        freq = (freq == 115) ? 110 : freq + 1;
                    }
                    cellTowers[neighbors[i]][3] = freq;
                }
            }
        }
    }
}