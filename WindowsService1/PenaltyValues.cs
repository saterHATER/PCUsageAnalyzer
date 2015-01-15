using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerUsageAnalyzer
{
    class PenaltyValues
    {
        private static DataTable _PenaltyWeek;
        private static char _esep = ' ';
        private static char _vsep = '#';

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
            int index = IndexOfRow(_PenaltyWeek, program);
            if (index < 0)
            {
                _PenaltyWeek.Rows.Add(
                    _PenaltyWeek.Rows.Count,    //row cout
                    program,                    //program name
                    "0" + _vsep + "0.0",        //Sunday
                    "0" + _vsep + "0.0",        //Monday
                    "0" + _vsep + "0.0",        //Tuesday
                    "0" + _vsep + "0.0",        //Wednesday
                    "0" + _vsep + "0.0",        //Thursday
                    "0" + _vsep + "0.0",        //Friday
                    "0" + _vsep + "0.0");       //Saturday
            }
            else
            {
                Console.WriteLine("Bull!! {0} is allready in this DT!", program);
            }
        }

        public void UpdateProgram(DataTable dt, String program, int day, int start, int end, double value)
        {
            int index = IndexOfRow(dt, program);
            if (index > (-1))
            {
                String currentEntry = dt.Rows[index][(day + 2)].ToString();
                currentEntry += _esep + start.ToString() + _vsep + value.ToString();
                value = value * (-1.0);
                currentEntry += _esep + end.ToString() + _vsep + value.ToString();
                dt.Rows[index][(day + 2)] = currentEntry;
            }
            else
            {
                Console.WriteLine("Bull!! {0} is not in this DT! I'll add it now!", program);
                AddNewProgram(program);
                Console.WriteLine("Adding it now!");
                UpdateProgram(dt, program, day, start, end, value);
            }
        }

        public double ReturnPenalty(DataTable dt, String program, DateTime time)
        {
            double penalty = 0.0;
            int index = IndexOfRow(dt, program);
            if (index > (-1))
            {
                int minute = (int) time.TimeOfDay.TotalMinutes;
                String entries = dt.Rows[index][((int)time.DayOfWeek + 2)].ToString();
                foreach (String entry in entries.Split(_esep))
                {
                    String[] values = entry.Split(_vsep);
                    int key = int.Parse(values[0]);
                    if (key <= minute)
                    {
                        penalty += double.Parse(values[1]);
                    }
                }
            }
            //else
            //{
            //    Console.WriteLine("Bull!! {0} is not in this DT!", program);
            //}
            return penalty;
        }

        private int IndexOfRow(DataTable dt, String program)
        {
            foreach (DataRow row in dt.Rows)
            {
                String selection = row["Program Name"].ToString();
                if (String.Compare(program,selection)==0)
                {
                    int rowLocation = int.Parse(row["Row Number"].ToString());
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
            return _PenaltyWeek.TableName;
        }

    }
}