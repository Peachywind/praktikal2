using Newtonsoft.Json;
using System.IO;

public static class MyConverter
{
    // Метод сериализации объекта в строку JSON и сохранения в файл
    public static void MySerealize<T>(T obj, string fileName = "C:\\Users\\Vladi\\OneDrive\\Рабочий стол\\pr2date\\myJson")
    {
        var jsonString = JsonConvert.SerializeObject(obj);
        File.WriteAllText(fileName, jsonString);
    }

    // Метод десериализации объекта из строки JSON из файла
    public static T MyDeserialize<T>(string fileName = "C:\\Users\\Vladi\\OneDrive\\Рабочий стол\\pr2date\\myJson") // я 
    {
        if (!File.Exists(fileName))
        {
            return default(T);
        }

        var jsonString = File.ReadAllText(fileName);
        return JsonConvert.DeserializeObject<T>(jsonString);
    }
}