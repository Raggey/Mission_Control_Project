using System;

public class tleFormat {


    public Tuple <string, string> getIssTle(byte[] bytes){
         // Just return the first 3 lines
        string buff = System.Text.Encoding.UTF8.GetString(bytes);
        string[] arr = buff.Split('\n');
       
        int zarya = 0;
        int zaryaTLE1 = 1;
        int zaryaTLE2 = 2;
        string retVal = arr[zarya] + "\n " + arr[zaryaTLE1] + "\n " + arr[zaryaTLE2];

        // var tleStrings = Tuple <string, string>;
        return Tuple.Create(arr[zaryaTLE1],  arr[zaryaTLE2]);
        
    }


}