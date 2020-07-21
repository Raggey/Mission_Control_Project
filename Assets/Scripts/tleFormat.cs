

public class tleFormat {


    public string getIssTle(byte[] bytes){
         // Just return the first 3 lines
        string buff = System.Text.Encoding.UTF8.GetString(bytes);
        string[] arr = buff.Split('\n');
       
        int zarya = 0;
        int zaryaTLE1 = 1;
        int zaryaTLE2 = 2;
        string retVal = arr[zarya] + "\n " + arr[zaryaTLE1] + "\n " + arr[zaryaTLE2];


        return retVal;
    }


}