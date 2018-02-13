using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace F1ConsoleApp
{
    public class UDPPacket
    {
        public UDPPacket()
        {
        }
        public UDPPacket(byte[] stream)
        {
            M_time = System.BitConverter.ToSingle(stream, 0);
            M_lapTime = System.BitConverter.ToSingle(stream, 4);
            M_lapDistance = System.BitConverter.ToSingle(stream, 8);
            M_totalDistance = System.BitConverter.ToSingle(stream, 12);
            M_x = System.BitConverter.ToSingle(stream, 16);
            M_y = System.BitConverter.ToSingle(stream, 20);
            M_z = System.BitConverter.ToSingle(stream, 24);
            M_speed = System.BitConverter.ToSingle(stream, 28);
            /*M_xv = System.BitConverter.ToSingle(stream, 32);
            M_yv = System.BitConverter.ToSingle(stream, 36);
            M_zv = System.BitConverter.ToSingle(stream, 40);
            M_xr = System.BitConverter.ToSingle(stream, 44);
            M_yr = System.BitConverter.ToSingle(stream, 48);
            M_zr = System.BitConverter.ToSingle(stream, 52);
            M_xd = System.BitConverter.ToSingle(stream, 56);
            M_yd = System.BitConverter.ToSingle(stream, 60);
            M_zd = System.BitConverter.ToSingle(stream, 64);
            M_susp_pos = new float[] { System.BitConverter.ToSingle(stream, 68), System.BitConverter.ToSingle(stream, 72), System.BitConverter.ToSingle(stream, 76), System.BitConverter.ToSingle(stream, 80) };
            M_susp_vel = new float[] { System.BitConverter.ToSingle(stream, 84), System.BitConverter.ToSingle(stream, 88), System.BitConverter.ToSingle(stream, 92), System.BitConverter.ToSingle(stream, 96) };
            M_wheel_speed = new float[] { System.BitConverter.ToSingle(stream, 100), System.BitConverter.ToSingle(stream, 104), System.BitConverter.ToSingle(stream, 108), System.BitConverter.ToSingle(stream, 112) };
            */
            M_throttle = System.BitConverter.ToSingle(stream, 116);
            M_steer = System.BitConverter.ToSingle(stream, 120);
            M_brake = System.BitConverter.ToSingle(stream, 124);
            M_clutch = System.BitConverter.ToSingle(stream, 128);
            M_gear = System.BitConverter.ToSingle(stream, 132);
            /*M_gforce_lat = System.BitConverter.ToSingle(stream, 136);
            M_gforce_lon = System.BitConverter.ToSingle(stream, 140);*/
            M_lap = System.BitConverter.ToSingle(stream, 144);
            M_engineRate = System.BitConverter.ToSingle(stream, 148);
            /*M_sli_pro_native_support = System.BitConverter.ToSingle(stream, 152);*/
            M_car_position = System.BitConverter.ToSingle(stream, 156);
            M_kers_level = System.BitConverter.ToSingle(stream, 160);
            M_kers_max_level = System.BitConverter.ToSingle(stream, 164);
            M_drs = System.BitConverter.ToSingle(stream, 168);
            M_traction_control = System.BitConverter.ToSingle(stream, 172);
            M_anti_lock_brakes = System.BitConverter.ToSingle(stream, 176);
            M_fuel_in_tank = System.BitConverter.ToSingle(stream, 180);
            M_fuel_capacity = System.BitConverter.ToSingle(stream, 184);
            M_in_pits = System.BitConverter.ToSingle(stream, 188);
            M_sector = System.BitConverter.ToSingle(stream, 192);
            M_sector1_time = System.BitConverter.ToSingle(stream, 196);
            M_sector2_time = System.BitConverter.ToSingle(stream, 200);
            M_brakes_temp = new float[] { System.BitConverter.ToSingle(stream, 204), System.BitConverter.ToSingle(stream, 208), System.BitConverter.ToSingle(stream, 212), System.BitConverter.ToSingle(stream, 216) };
            M_tyres_pressure = new float[] { System.BitConverter.ToSingle(stream, 220), System.BitConverter.ToSingle(stream, 224), System.BitConverter.ToSingle(stream, 228), System.BitConverter.ToSingle(stream, 232) };
            M_teaM_info = System.BitConverter.ToSingle(stream, 236);
            M_total_laps = System.BitConverter.ToSingle(stream, 240);
            M_track_size = System.BitConverter.ToSingle(stream, 244);
            M_last_lap_time = System.BitConverter.ToSingle(stream, 248);
            M_max_rpm = System.BitConverter.ToSingle(stream, 252);
            M_idle_rpm = System.BitConverter.ToSingle(stream, 256);
            M_max_gears = System.BitConverter.ToSingle(stream, 260);
            M_sessionType = System.BitConverter.ToSingle(stream, 264);
            M_drsAllowed = System.BitConverter.ToSingle(stream, 268);
            M_track_number = System.BitConverter.ToSingle(stream, 272);
            M_vehicleFIAFlags = System.BitConverter.ToSingle(stream, 276);
            M_era = System.BitConverter.ToSingle(stream, 280);
            M_engine_temperature = System.BitConverter.ToSingle(stream, 284);
            //M_gforce_vert = System.BitConverter.ToSingle(stream, 288);
            /*M_ang_vel_x = System.BitConverter.ToSingle(stream, 292);
            M_ang_vel_y = System.BitConverter.ToSingle(stream, 296);
            M_ang_vel_z = System.BitConverter.ToSingle(stream, 300);
            */
            M_tyres_temperature = new byte[] { stream[304], stream[305], stream[306], stream[307] };
            M_tyres_wear = new byte[] { stream[308], stream[309], stream[310], stream[311] };
            M_tyre_compound = stream[312];
            M_front_brake_bias = stream[313];
            M_fuel_mix = stream[314];
            M_currentLapInvalid = stream[315];
            M_tyres_damage = new byte[] { stream[316], stream[317], stream[318], stream[319] };
            M_front_left_wing_damage = stream[320];
            M_front_right_wing_damage = stream[321];
            M_rear_wing_damage = stream[322];
            M_engine_damage = stream[323];
            M_gear_box_damage = stream[324];
            M_exhaust_damage = stream[325];
            M_pit_limiter_status = stream[326];
            M_pit_speed_limit = stream[327];
            M_session_time_left = System.BitConverter.ToSingle(stream, 328);
            M_rev_lights_percent = stream[332];
            M_is_spectating = stream[333];
            M_spectator_car_index = stream[334];
            M_num_cars = stream[335];
            M_player_car_index = stream[336];
            /*
            byte[] target = new byte[840];
            Array.Copy(stream, 337, target, 0, 840);
            M_car_data = CarUDPData.getCars(target);

            M_yaw = System.BitConverter.ToSingle(stream, 1177);
            M_pitch = System.BitConverter.ToSingle(stream, 1181);
            M_roll = System.BitConverter.ToSingle(stream, 1185);
            M_x_local_velocity = System.BitConverter.ToSingle(stream, 1189);
            M_y_local_velocity = System.BitConverter.ToSingle(stream, 1193);
            M_z_local_velocity = System.BitConverter.ToSingle(stream, 1197);
            M_susp_acceleration = new float[] { System.BitConverter.ToSingle(stream, 1261), System.BitConverter.ToSingle(stream, 1265), System.BitConverter.ToSingle(stream, 1269), System.BitConverter.ToSingle(stream, 1273) };
            M_ang_acc_x = System.BitConverter.ToSingle(stream, 1277);
            M_ang_acc_y = System.BitConverter.ToSingle(stream, 1281);
            M_ang_acc_z = System.BitConverter.ToSingle(stream, 1285);
            */
        }

        //[JsonProperty(PropertyName = "M_time")]
        public float M_time { get; set; }

        //[JsonProperty(PropertyName = "M_lapTime")]
        public float M_lapTime { get; set; }

        //[JsonProperty(PropertyName = "M_lapDistance")]
        public float M_lapDistance { get; set; }

        //[JsonProperty(PropertyName = "M_totalDistance")]
        public float M_totalDistance { get; set; }

        //[JsonProperty(PropertyName = "M_x")]
        public float M_x { get; set; } // World space position

        //[JsonProperty(PropertyName = "M_y")]
        public float M_y { get; set; } // World space position

        //[JsonProperty(PropertyName = "M_z")]
        public float M_z { get; set; } // World space position

        //[JsonProperty(PropertyName = "M_speed")]
        public float M_speed { get; set; } // Speed of car in MPH

        //[JsonProperty(PropertyName = "M_xv")]
        public float M_xv { get; set; } // Velocity in world space

        //[JsonProperty(PropertyName = "M_yv")]
        public float M_yv { get; set; } // Velocity in world space

        //[JsonProperty(PropertyName = "M_zv")]
        public float M_zv { get; set; } // Velocity in world space

        //[JsonProperty(PropertyName = "M_xr")]
        public float M_xr { get; set; } // World space right direction

        //[JsonProperty(PropertyName = "M_yr")]
        public float M_yr { get; set; } // World space right direction

        //[JsonProperty(PropertyName = "M_zr")]
        public float M_zr { get; set; } // World space right direction

        //[JsonProperty(PropertyName = "M_xd")]
        public float M_xd { get; set; } // World space forward direction

        //[JsonProperty(PropertyName = "M_yd")]
        public float M_yd{ get; set; } // World space forward direction

        //[JsonProperty(PropertyName = "M_zd")]
        public float M_zd{ get; set; } // World space forward direction

        //[JsonProperty(PropertyName = "M_susp_pos")]
        public float[] M_susp_pos{ get; set; } // Note: All wheel arrays have the order:

        //[JsonProperty(PropertyName = "M_susp_vel")]
        public float[] M_susp_vel{ get; set; } // RL, RR, FL, FR

        //[JsonProperty(PropertyName = "M_wheel_speed")]
        public float[] M_wheel_speed{ get; set; }

        //[JsonProperty(PropertyName = "M_throttle")]
        public float M_throttle{ get; set; }

        //[JsonProperty(PropertyName = "M_steer")]
        public float M_steer{ get; set; }

        //[JsonProperty(PropertyName = "M_brake")]
        public float M_brake{ get; set; }

        //[JsonProperty(PropertyName = "M_clutch")]
        public float M_clutch{ get; set; }

        //[JsonProperty(PropertyName = "M_gear")]
        public float M_gear{ get; set; }

        //[JsonProperty(PropertyName = "M_gforce_lat")]
        public float M_gforce_lat{ get; set; }

        //[JsonProperty(PropertyName = "M_gforce_lon")]
        public float M_gforce_lon{ get; set; }

        //[JsonProperty(PropertyName = "M_lap")]
        public float M_lap{ get; set; }

        //[JsonProperty(PropertyName = "M_engineRate")]
        public float M_engineRate{ get; set; }

        //[JsonProperty(PropertyName = "M_sli_pro_native_support")]
        public float M_sli_pro_native_support{ get; set; } // SLI Pro support

        //[JsonProperty(PropertyName = "M_car_position")]
        public float M_car_position{ get; set; } // car race position

        //[JsonProperty(PropertyName = "M_kers_level")]
        public float M_kers_level{ get; set; } // kers energy left

        //[JsonProperty(PropertyName = "M_kers_max_level")]
        public float M_kers_max_level{ get; set; } // kers maximum energy

        //[JsonProperty(PropertyName = "M_drs")]
        public float M_drs{ get; set; } // 0 = off, 1 = on

        //[JsonProperty(PropertyName = "M_traction_control")]
        public float M_traction_control{ get; set; } // 0 (off) - 2 (high)

        //[JsonProperty(PropertyName = "M_anti_lock_brakes")]
        public float M_anti_lock_brakes{ get; set; } // 0 (off) - 1 (on)

        //[JsonProperty(PropertyName = "M_fuel_in_tank")]
        public float M_fuel_in_tank{ get; set; } // current fuel mass

        //[JsonProperty(PropertyName = "M_fuel_capacity")]
        public float M_fuel_capacity{ get; set; } // fuel capacity

        //[JsonProperty(PropertyName = "M_in_pits")]
        public float M_in_pits{ get; set; } // 0 = none, 1 = pitting, 2 = in pit area

        //[JsonProperty(PropertyName = "M_sector")]
        public float M_sector{ get; set; } // 0 = sector1, 1 = sector2, 2 = sector3

        //[JsonProperty(PropertyName = "M_sector1_time")]
        public float M_sector1_time{ get; set; } // time of sector1 (or 0)

        //[JsonProperty(PropertyName = "M_sector2_time")]
        public float M_sector2_time{ get; set; } // time of sector2 (or 0)

        //[JsonProperty(PropertyName = "M_brakes_temp")]
        public float[] M_brakes_temp{ get; set; } // brakes temperature (centigrade)

        //[JsonProperty(PropertyName = "M_tyres_pressure")]
        public float[] M_tyres_pressure{ get; set; } // tyres pressure PSI

        //[JsonProperty(PropertyName = "M_teaM_info")]
        public float M_teaM_info{ get; set; } // team ID 

        //[JsonProperty(PropertyName = "M_total_laps")]
        public float M_total_laps{ get; set; } // total number of laps in this race

        //[JsonProperty(PropertyName = "M_track_size")]
        public float M_track_size{ get; set; } // track size meters

        //[JsonProperty(PropertyName = "M_last_lap_time")]
        public float M_last_lap_time{ get; set; } // last lap time

        //[JsonProperty(PropertyName = "M_max_rpm")]
        public float M_max_rpm{ get; set; } // cars max RPM, at which point the rev limiter will kick in

        //[JsonProperty(PropertyName = "M_idle_rpm")]
        public float M_idle_rpm{ get; set; } // cars idle RPM

        //[JsonProperty(PropertyName = "M_max_gears")]
        public float M_max_gears{ get; set; } // maximum number of gears

        //[JsonProperty(PropertyName = "M_sessionType")]
        public float M_sessionType{ get; set; } // 0 = unknown, 1 = practice, 2 = qualifying, 3 = race

        //[JsonProperty(PropertyName = "M_drsAllowed")]
        public float M_drsAllowed{ get; set; } // 0 = not allowed, 1 = allowed, -1 = invalid / unknown

        //[JsonProperty(PropertyName = "M_track_number")]
        public float M_track_number{ get; set; } // -1 for unknown, 0-21 for tracks

        //[JsonProperty(PropertyName = "M_vehicleFIAFlags")]
        public float M_vehicleFIAFlags{ get; set; } // -1 = invalid/unknown, 0 = none, 1 = green, 2 = blue, 3 = yellow, 4 = red

        //[JsonProperty(PropertyName = "M_era")]
        public float M_era{ get; set; }                     // era, 2017 (modern) or 1980 (classic)

        //[JsonProperty(PropertyName = "M_engine_temperature")]
        public float M_engine_temperature{ get; set; }   // engine temperature (centigrade)

        //[JsonProperty(PropertyName = "M_gforce_vert")]
        public float M_gforce_vert{ get; set; } // vertical g-force component

        //[JsonProperty(PropertyName = "M_ang_vel_x")]
        public float M_ang_vel_x{ get; set; } // angular velocity x-component

        //[JsonProperty(PropertyName = "M_ang_vel_y")]
        public float M_ang_vel_y{ get; set; } // angular velocity y-component

        //[JsonProperty(PropertyName = "M_ang_vel_z")]
        public float M_ang_vel_z{ get; set; } // angular velocity z-component

        //[JsonProperty(PropertyName = "M_tyres_temperature")]
        public byte[] M_tyres_temperature{ get; set; } // tyres temperature (centigrade)

        //[JsonProperty(PropertyName = "M_tyres_wear")]
        public byte[] M_tyres_wear{ get; set; } // tyre wear percentage

        //[JsonProperty(PropertyName = "M_tyre_compound")]
        public byte M_tyre_compound{ get; set; } // compound of tyre – 0 = ultra soft, 1 = super soft, 2 = soft, 3 = medium, 4 = hard, 5 = inter, 6 = wet

        //[JsonProperty(PropertyName = "M_front_brake_bias")]
        public byte M_front_brake_bias{ get; set; }         // front brake bias (percentage)

        //[JsonProperty(PropertyName = "M_fuel_mix")]
        public byte M_fuel_mix{ get; set; }                 // fuel mix - 0 = lean, 1 = standard, 2 = rich, 3 = max

        //[JsonProperty(PropertyName = "M_currentLapInvalid")]
        public byte M_currentLapInvalid{ get; set; }     // current lap invalid - 0 = valid, 1 = invalid

        //[JsonProperty(PropertyName = "M_tyres_damage")]
        public byte[] M_tyres_damage{ get; set; } // tyre damage (percentage)

        //[JsonProperty(PropertyName = "M_front_left_wing_damage")]
        public byte M_front_left_wing_damage{ get; set; } // front left wing damage (percentage)

        //[JsonProperty(PropertyName = "M_front_right_wing_damage")]
        public byte M_front_right_wing_damage{ get; set; } // front right wing damage (percentage)

        //[JsonProperty(PropertyName = "M_rear_wing_damage")]
        public byte M_rear_wing_damage{ get; set; } // rear wing damage (percentage)

        //[JsonProperty(PropertyName = "M_engine_damage")]
        public byte M_engine_damage{ get; set; } // engine damage (percentage)

        //[JsonProperty(PropertyName = "M_gear_box_damage")]
        public byte M_gear_box_damage{ get; set; } // gear box damage (percentage)

        //[JsonProperty(PropertyName = "M_exhaust_damage")]
        public byte M_exhaust_damage{ get; set; } // exhaust damage (percentage)

        //[JsonProperty(PropertyName = "username")]
        public byte M_pit_limiter_status{ get; set; } // pit limiter status – 0 = off, 1 = on

        //[JsonProperty(PropertyName = "M_pit_speed_limit")]
        public byte M_pit_speed_limit{ get; set; } // pit speed limit in mph

        //[JsonProperty(PropertyName = "M_session_time_left")]
        public float M_session_time_left{ get; set; }  // NEW: time left in session in seconds 

        //[JsonProperty(PropertyName = "M_rev_lights_percent")]
        public byte M_rev_lights_percent{ get; set; }  // NEW: rev lights indicator (percentage)

        //[JsonProperty(PropertyName = "M_is_spectating")]
        public byte M_is_spectating{ get; set; }  // NEW: whether the player is spectating

        //[JsonProperty(PropertyName = "M_spectator_car_index")]
        public byte M_spectator_car_index{ get; set; }  // NEW: index of the car being spectated

        // Car data

        //[JsonProperty(PropertyName = "M_num_cars")]
        public byte M_num_cars{ get; set; }               // number of cars in data

        //[JsonProperty(PropertyName = "M_player_car_index")]
        public byte M_player_car_index{ get; set; }         // index of player's car in the array
        public CarUDPData[] M_car_data{ get; set; }   // data for all cars on track

        //[JsonProperty(PropertyName = "M_yaw")]
        public float M_yaw{ get; set; }  // NEW (v1.8)

        //[JsonProperty(PropertyName = "M_pitch")]
        public float M_pitch{ get; set; }  // NEW (v1.8)

        //[JsonProperty(PropertyName = "M_roll")]
        public float M_roll{ get; set; }  // NEW (v1.8)

        //[JsonProperty(PropertyName = "M_x_local_velocity")]
        public float M_x_local_velocity{ get; set; }          // NEW (v1.8) Velocity in local space

        //[JsonProperty(PropertyName = "M_y_local_velocity")]
        public float M_y_local_velocity{ get; set; }          // NEW (v1.8) Velocity in local space

        //[JsonProperty(PropertyName = "M_z_local_velocity")]
        public float M_z_local_velocity{ get; set; }          // NEW (v1.8) Velocity in local space

        //[JsonProperty(PropertyName = "M_susp_acceleration")]
        public float[] M_susp_acceleration{ get; set; }   // NEW (v1.8) RL, RR, FL, FR

        //[JsonProperty(PropertyName = "M_ang_acc_x")]
        public float M_ang_acc_x{ get; set; }                 // NEW (v1.8) angular acceleration x-component

        //[JsonProperty(PropertyName = "M_ang_acc_y")]
        public float M_ang_acc_y{ get; set; }                 // NEW (v1.8) angular acceleration y-component

        //[JsonProperty(PropertyName = "M_ang_acc_z")]
        public float M_ang_acc_z { get; set; }                 // NEW (v1.8) angular acceleration z-component                
    }
}
