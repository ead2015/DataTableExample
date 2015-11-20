using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace DataTableExample
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable StudentTable = new DataTable("Students");
            
            DataColumn StudentIdColumn = new DataColumn("Id", typeof(int));
            DataColumn StudentNameColumn = new DataColumn("FullName",typeof(string));
            DataColumn StudentAgeColumn = new DataColumn("Age", typeof(int));

            StudentIdColumn.AutoIncrement = true;
            StudentIdColumn.AutoIncrementSeed = 1;
            StudentIdColumn.AutoIncrementStep = 1;

            StudentTable.Columns.Add(StudentIdColumn);
            StudentTable.Columns.Add(StudentNameColumn);
            StudentTable.Columns.Add(StudentAgeColumn);
            StudentTable.PrimaryKey = new DataColumn[] { StudentIdColumn};

            DataRow r1 = StudentTable.NewRow();
            try
            {
                //object 
                r1.BeginEdit();
                r1["FullName"] = "Some Value";
                r1["Age"] = 23;
                r1.EndEdit();
            }
            catch {
                r1.CancelEdit();
            }
            //Adding New Row
            StudentTable.Rows.Add(r1);
            //StudentTable.Rows.InsertAt(r1, 0);

            foreach (DataRow r in StudentTable.Rows)
            {
                //returning as object and need type cast if storing in int e.g int i= (int)r[0];
                Console.WriteLine("Id ="+ r[0]);
                Console.WriteLine("Full Name =" + r[1]);
                Console.WriteLine("Age =" + r[2]);
            }

            //Edit a Row.
           
            try
            {
                r1.BeginEdit();
                r1["FullName"] = "Some New Name ";
                r1["Age"] = "12eer";
                r1.EndEdit();
            }
            catch {
                r1.CancelEdit();
            }
            
            //DataRow r2 = StudentTable.Rows[0];
            //r2["FullName"] = "This is Awesome New Name";
            foreach (DataRow r in StudentTable.Rows)
            {
                //returning as object and need type cast if storing in int e.g int i= (int)r[0];
                Console.WriteLine("Id =" + r[0]);
                Console.WriteLine("Full Name =" + r[1]);
                Console.WriteLine("Age =" + r[2]);
               // r[1] = "My New Name";
            }

            //removing
           // StudentTable.Rows.Remove(r1);
            //StudentTable.Rows.RemoveAt(0);
          
            //to remove all data..
          //  StudentTable.Rows.Clear();
            
            //foreach (DataRow r in StudentTable.Rows)
                //{
            //    //returning as object and need type cast if storing in int e.g int i= (int)r[0];
            //    Console.WriteLine("Id =" + r[0]);
            //    Console.WriteLine("Full Name =" + r[1]);
            //    Console.WriteLine("Age =" + r[2]);
            //}

            //searching

            //by primary Key
            //input is object
            DataRow row = StudentTable.Rows.Find(1);
            
            //By Search criteria
            DataRow[] rows = StudentTable.Select(" Age > 24 OR FullName like 'S%'");
            //DataRow[] rows = StudentTable.Select(" Age > 24 OR FullName like 'S%'", " Age Desc");
            //check chapter 4, page 63 for list of operations


        }//main
    }
}
