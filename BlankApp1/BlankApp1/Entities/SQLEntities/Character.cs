using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlankApp1.Entities.SQLEntities
{
    public class Character
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
