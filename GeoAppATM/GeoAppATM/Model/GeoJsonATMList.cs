﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GeoAppATM.Model
{

    /// <summary>
    /// Тип данных для чтения банкоматов из geojson
    /// </summary>
    public class GeoJsonATMList
    {
        [JsonPropertyName("features")]
        public List<GeoJsonATM> ATMs { get; set; }
    }
    /// <summary>
    /// Класс содержащий информацию о банкомате
    /// </summary>
    public class GeoJsonATM
    {
        /// <summary>
        /// Координаты банкомата
        /// </summary>
        [JsonPropertyName("geometry")]
        public Geometry Geometry { get; set; }

        /// <summary>
        /// Идентификатор, оператор, баланс
        /// </summary>
        [JsonPropertyName("properties")]
        public Properties Properties { get; set; }

        /// <summary>
        /// Сравнение двух банкоматов
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is GeoJsonATM atm &&
                atm.Geometry.Coordinates[0] == Geometry.Coordinates[0] &&
                atm.Geometry.Coordinates[1] == Geometry.Coordinates[1] &&
                atm.Properties.Id == Properties.Id &&
                atm.Properties.Operator == Properties.Operator &&
                atm.Properties.Balance == Properties.Balance;
        }

        /// <summary>
        /// Хеш-код банкомата по его идентификатору
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            try
            {
                return int.Parse(Properties.Id);
            }
            catch
            {
                return 0;
            }
        }
    }

    /// <summary>
    /// Класс для хранения координат
    /// </summary>
    public class Geometry
    {
        [JsonPropertyName("coordinates")]
        public List<double> Coordinates { get; set; }
    }

    /// <summary>
    /// Класс для хранения идентификатора, оператора, баланса
    /// </summary>
    public class Properties
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("operator")]
        public string Operator { get; set; }

        [JsonPropertyName("balance")]
        public int Balance { get; set; }
    }
}