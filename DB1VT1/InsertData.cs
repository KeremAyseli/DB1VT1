namespace DB1VT1
{
    public class InsertData<T>
    {
        public void Insert(string tableName, T data, string keyword)
        {
            DataWrite<T> dataWrite = new DataWrite<T>();
            dataWrite.dataWrite(tableName, data, keyword);
        }
    }
}
