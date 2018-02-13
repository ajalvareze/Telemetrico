using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace F1ConsoleApp
{
    public class CarUDPData
    {
        public CarUDPData(byte[] stream) {
            M_worldPosition = new float[] { System.BitConverter.ToSingle(stream, 0), System.BitConverter.ToSingle(stream, 4), System.BitConverter.ToSingle(stream, 8) };
            M_lastLapTime = System.BitConverter.ToSingle(stream, 12);
            M_currentLapTime = System.BitConverter.ToSingle(stream, 16);
            M_bestLapTime = System.BitConverter.ToSingle(stream, 20);
            M_sector1Time = System.BitConverter.ToSingle(stream, 24);
            M_sector2Time = System.BitConverter.ToSingle(stream, 28);
            M_lapDistance = System.BitConverter.ToSingle(stream, 32);
            M_driverId = stream[33];
            M_teamId = stream[34];
            M_carPosition = stream[35];
            M_currentLapNum = stream[36];
            M_tyreCompound = stream[37];
            M_inPits = stream[38];
            M_sector = stream[39];
            M_currentLapInvalid = stream[40];
            M_penalties = stream[41];
        }

        public static CarUDPData[] getCars(byte[] data)
        {
            int currentByte = 0;
            int carBytes = 42;
            CarUDPData[] cars = new CarUDPData[20];
            for(int i = 0; i< cars.Length; i++)
            {
                byte[] target = new byte[carBytes];
                Array.Copy(data, currentByte, target, 0, carBytes);
                cars[i] = new CarUDPData(target);
                currentByte += carBytes;
            }
            return cars;
        }

        //[JsonProperty(PropertyName = "M_worldPosition")]
        public float[] M_worldPosition{get; set; }

        //[JsonProperty(PropertyName = "M_lastLapTime")]
        public float M_lastLapTime{get; set; }

        //[JsonProperty(PropertyName = "M_currentLapTime")]
        public float M_currentLapTime{get; set; }

        //[JsonProperty(PropertyName = "M_bestLapTime")]
        public float M_bestLapTime{get; set; }

        //[JsonProperty(PropertyName = "M_sector1Time")]
        public float M_sector1Time{get; set; }

        //[JsonProperty(PropertyName = "M_sector2Time")]
        public float M_sector2Time{get; set; }

        //[JsonProperty(PropertyName = "M_lapDistance")]
        public float M_lapDistance{get; set; }

        //[JsonProperty(PropertyName = "M_driverId")]
        public byte M_driverId{get; set; }

        //[JsonProperty(PropertyName = "M_teamId")]
        public byte M_teamId{get; set; }

        //[JsonProperty(PropertyName = "M_carPosition")]
        public byte M_carPosition{get; set; }     // UPDATED: track positions of vehicle

        //[JsonProperty(PropertyName = "M_currentLapNum")]
        public byte M_currentLapNum{get; set; }

        //[JsonProperty(PropertyName = "M_tyreCompound")]
        public byte M_tyreCompound{get; set; } // compound of tyre – 0 = ultra soft, 1 = super soft, 2 = soft, 3 = medium, 4 = hard, 5 = inter, 6 = wet

        //[JsonProperty(PropertyName = "M_inPits")]
        public byte M_inPits{get; set; }           // 0 = none, 1 = pitting, 2 = in pit area

        //[JsonProperty(PropertyName = "M_sector")]
        public byte M_sector{get; set; }           // 0 = sector1, 1 = sector2, 2 = sector3

        //[JsonProperty(PropertyName = "M_currentLapInvalid")]
        public byte M_currentLapInvalid{get; set; } // current lap invalid - 0 = valid, 1 = invalid

        //[JsonProperty(PropertyName = "M_penalties")]
        public byte M_penalties {get; set; }  // NEW: accumulated time penalties in seconds to be added
    }
}
