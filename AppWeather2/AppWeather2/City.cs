using System;
using SQLite;

namespace AppWeather2
{
    [Table("Cities")]
    public class City
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Name_City { get; set; }
        public int Temperature { get; set; }
        public int Wind_speed { get; set; }
        public int Wind_line { get; set; }

        public string Name_get
        {
            get
            {
                return "Город: " + Name_City;
            }
        }

        public string Temp_get
        {
            get
            {
                string str = " С";
                str += (char)176;
                return "Температура: " + Convert.ToString(Temperature) + str;
            }
        }

        public string Speed_get
        {
            get
            {
                return "Скорость ветра: " + Convert.ToString(Wind_speed) + " м/с";
            }
        }

        public string Line_get
        {
            get
            {
                return "Направление ветра: " + WindLineTransform(Wind_line);
            }
        }

        public City() { }
        public City(string Name_City, int Temperature, int Wind_speed, int Wind_line)
        {
            this.Name_City = Name_City;
            this.Temperature = Temperature;
            this.Wind_speed = Wind_speed;
            this.Wind_line = Wind_line;
        }

        public string WindLineTransform(int wl)
        {

            if (wl >= 0 & wl <= 180)
            {
                if (wl >= 0 & wl <= 90)
                {
                    if (wl >= 0 & wl <= 30)
                    {
                        return "ССВ";
                    }

                    if (wl >= 30 & wl <= 60)
                    {
                        return "СВ";
                    }

                    if (wl >= 60 & wl <= 90)
                    {
                        return "ВСВ";
                    }
                }
                if (wl >= 90 & wl <= 180)
                {
                    if (wl >= 90 & wl <= 120)
                    {
                        return "ВЮВ";
                    }

                    if (wl >= 120 & wl <= 150)
                    {
                        return "ЮВ";
                    }

                    if (wl >= 150 & wl <= 180)
                    {
                        return "ЮЮВ";
                    }
                }
            }

            if (wl >= 180 & wl <= 270)
            {
                if (wl >= 180 & wl <= 210)
                {
                    return "ЮЮЗ";
                }

                if (wl >= 210 & wl <= 240)
                {
                    return "ЮЗ";
                }

                if (wl >= 240 & wl <= 270)
                {
                    return "ЗЮЗ";
                }
            }

            if (wl >= 270 & wl <= 360)
            {
                if (wl >= 270 & wl <= 300)
                {
                    return "ЗСЗ";
                }

                if (wl >= 300 & wl <= 330)
                {
                    return "СЗ";
                }

                if (wl >= 330 & wl <= 360)
                {
                    return "ССЗ";
                }
            }

            return "null";
        }

    }
}
