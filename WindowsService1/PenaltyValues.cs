using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    class PenaltyValues
    {
        private static DataTable _PenaltyWeek;

        public PenaltyValues()
        {
            _PenaltyWeek = new DataTable();
            _PenaltyWeek.Columns.Add("Row Number", typeof(int));
            _PenaltyWeek.Columns.Add("Program Name", typeof(String));
            _PenaltyWeek.Columns.Add("Sunday", typeof(String));
            _PenaltyWeek.Columns.Add("Monday", typeof(String));
            _PenaltyWeek.Columns.Add("Tuesday", typeof(String));
            _PenaltyWeek.Columns.Add("Wednesday", typeof(String));
            _PenaltyWeek.Columns.Add("Thursday", typeof(String));
            _PenaltyWeek.Columns.Add("Friday", typeof(String));
            _PenaltyWeek.Columns.Add("Saturday", typeof(String));

            _PenaltyWeek.TableName = "Penalties_" + Environment.UserName.ToString();
        }

        public void AddNewProgram(String program)
        {
            foreach (DataRow row in _PenaltyWeek.Rows)
            {
                if (row.ItemArray[0].Equals(program))
                {
                    Console.WriteLine("Bull!! {0} is allready in this DT!", program);
                    return;
                }
            }
            _PenaltyWeek.Rows.Add(
                _PenaltyWeek.Rows.Count,    //row cout
                program,                    //program name
                "0-0.0",                    //Sunday
                "0-0.0",                    //Monday
                "0-0.0",                    //Tuesday
                "0-0.0",                    //Wednesday
                "0-0.0",                    //Thursday
                "0-0.0",                    //Friday
                "0-0.0");                   //Saturday
        }

        public void UpdateProgram(String program, int day, int start, int end, double value)
        {
            int index = IndexOfRow(program);
            if (index > (-1))
            {
                String currentEntry = _PenaltyWeek.Rows[index][(day + 2)].ToString();
                currentEntry += " " + start.ToString() + "-" + value.ToString();
                value = value * (-1.0);
                currentEntry += " " + end.ToString() + "-" + value.ToString();
                _PenaltyWeek.Rows[index][(day + 2)] = currentEntry;
            }
            else
            {
                Console.WriteLine("Bull!! {0} is not in this DT!", program);
            }
        }

        public double ReturnPenalty(String program, DateTime time)
        {
            double penalty = 0.0;
            int index = IndexOfRow(program);
            if (index > (-1))
            {
                int minute = (int)time.Minute;
                String entries = _PenaltyWeek.Rows[index][((int)time.DayOfWeek + 2)].ToString();
                foreach (String entry in entries.Split(' '))
                {
                    String[] values = entry.Split('-');
                    int key = int.Parse(values[0]);
                    if (key <= minute)
                    {
                        penalty += double.Parse(values[1]);
                    }
                }
            }
            else
            {
                Console.WriteLine("Bull!! {0} is not in this DT!", program);
            }
            return penalty;
        }

        private int IndexOfRow(String program)
        {
            foreach (DataRow row in _PenaltyWeek.Rows)
            {
                String selection = row.ItemArray[1].ToString();
                if (String.Compare(program,selection)==0)
                {
                    int rowLocation = (int) row.ItemArray[0];
                    return rowLocation;
                }
            }
            return (int)(-1);
        }

        public void InsertDataTable(DataTable newDT)
        {
            _PenaltyWeek = newDT;
        }

        public DataTable GetDataTable()
        {
            return _PenaltyWeek;
        }

        public void print()
        {
            foreach (DataRow row in _PenaltyWeek.Rows)
            {
                foreach (Object item in row.ItemArray)
                {
                    Console.Write(item.ToString() + "\v\v");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public String Title()
        {
            return _PenaltyWeek.TableName.ToString();
        }

    }
}