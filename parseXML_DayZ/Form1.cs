using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace parseXML_DayZ
{
    public partial class Form1 : Form
    {
        // file name: mapgrouppos.xml
        // 
        List<single_group> group_list = new List<single_group>(); // this will hold the parsed Xml data
        List<string> unique_model_name_list = new List<string>(); // a list of all unique model names for different uses

        List<map_group> map_list = new List<map_group>(); // this will hold the parsed data
        //List<string> unique_map_name_list = new List<string>(); // a list of all unique town/city/misc names for different uses

        class single_group
        {
            public string name = "";
            public string pos = "";
            public string rpy = "";
            public string a = "";
        }

        class map_group                     //
        {                                   //
            public string mapname = "";     //
            public string mappos = "";      // New Code
            public double posx = 0;         // New Code
            public double posz = 0;         // New Code
            public double posy = 0;         // New Code
                                            //
        }                                   //

        public Form1()
        {
            InitializeComponent();

            try
            {
                parseXmlFileLinq();
                cbALLUNIQUEENTRIES.SelectedIndex = 0;
                cbALLUNIQUEMAPENTRIES.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                txtOUTPUT.AppendText("\r\n[ERROR] COULD NOT PARSE XML:\r\n" + ex);
            }
        }


        private void RADIUSTESTINGAREA()
        {
            //bcoord = bcoordx & bcoordy
            //mcoord = mcoordx & mcoordy
            //bool maptracex = false
            //bool maptracey = false
            
            //foreach ()

            //    if(bcoordx + 100 <= mcoordx) && (bcoordx - 100 <= mcoordx)
            //    {
            //        maptracex = true;
            //    }
            //    else
            //    {
            //        maptracex =false;
            //    } 
            //    if(bcoordy + 100 <= mcoordy) && (bcoordy - 100 <= mcoordy2)
            //    {
            //        maptracey = true;
            //    }
            //    else
            //    {
            //        maptracey=false; 
            // 
        }

        private void parseXmlFileLinq()
        {
            // Clearing the group_list at the start gives us the flexibility
            // to change the xml file on the fly and get updated output without
            // having to restart the program
            if (group_list.Count > 0)
            {
                group_list.Clear();
                unique_model_name_list.Clear();
                cbALLUNIQUEENTRIES.Items.Clear();
                group_list = new List<single_group>();
                unique_model_name_list = new List<string>();
            }
            if (map_list.Count > 0)                                         //    New Code         
            {                                                               //
                map_list.Clear();                                           //
                //unique_map_name_list.Clear();                               //
               //unique_map_name_list = new List<string>();                   // 
                map_list = new List<map_group>();                        //      
                //cbALLUNIQUEMAPENTRIES.Items.Clear();                           //
                                                                            //
            }

            // load xelement with the data from our xml file
            XElement xelement = XElement.Load("mapgrouppos.xml");
            IEnumerable<XElement> group_attr = xelement.Elements();

            XElement melement = XElement.Load("mapnamepos.xml");
            IEnumerable<XElement> mgroup_attr = melement.Elements();

            txtOUTPUT.AppendText("\r\n**********************************************");
            txtOUTPUT.AppendText("\r\n** PLEASE WAIT - READING A LOT OF DATA **");
            txtOUTPUT.AppendText("\r\n**********************************************\r\n");

            foreach (var ga in group_attr)
            {
                // populate the combo box with only unique model names
                bool found = false;
                for (int j = 0; j < group_list.Count; ++j)
                {
                    if (group_list[j].name == ga.Attribute("name").Value)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    // model's name was not found in existing records,
                    // add it to unique names list
                    unique_model_name_list.Add(ga.Attribute("name").Value);
                }

                single_group temp_group = new single_group();
                temp_group.name = ga.Attribute("name").Value;
                temp_group.pos = ga.Attribute("pos").Value;
                temp_group.rpy = ga.Attribute("rpy").Value;
                temp_group.a = ga.Attribute("a").Value;

                // build our group list array in memory of all entries in the xml file
                group_list.Add(temp_group);
                //txtOUTPUT.AppendText("Name = " + ga.Attribute("name").Value + "\r\n");
                //txtOUTPUT.AppendText("pos = "  + ga.Attribute("pos").Value  + "\r\n");
                //txtOUTPUT.AppendText("rpy = "  + ga.Attribute("rpy").Value  + "\r\n");
                //txtOUTPUT.AppendText("a = "    + ga.Attribute("a").Value    + "\r\n");
            }


            ////////////////////////////////////////////////////////////////////////////////////////

            foreach (var ma in mgroup_attr)
            {

                map_group temp_mgroup = new map_group();
                temp_mgroup.mapname = ma.Attribute("name").Value;
                temp_mgroup.mappos = ma.Attribute("pos").Value;
                map_list.Add(temp_mgroup);

            }

            ////////////////////////////////////////////////////////////////////////////////////////


            // sort them alphabetically then populate the combo box with it
            unique_model_name_list.Sort();
            for (int i = 0; i < unique_model_name_list.Count; i++)
            {
                cbALLUNIQUEENTRIES.Items.Add(unique_model_name_list[i]);
            }


            /////////////////////////////////////////////////////////////////////////////////////
            for (int p = 0; p < map_list.Count; p++)
            {
                cbALLUNIQUEMAPENTRIES.Items.Add(map_list[p].mapname);
            }
            /////////////////////////////////////////////////////////////////////////////////////
            

            txtOUTPUT.AppendText("Total unique group names added: " + unique_model_name_list.Count + "\r\n");
            txtOUTPUT.AppendText("Total unique map names added: " + map_list.Count + "\r\n");
        }

        private void btnPARSE_Click(object sender, EventArgs e)
        {
            try
            {
                parseXmlFileLinq();
                cbALLUNIQUEENTRIES.SelectedIndex = 0;
                cbALLUNIQUEMAPENTRIES.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                txtOUTPUT.AppendText("\r\n[ERROR] COULD NOT PARSE XML:\r\n" + ex);
            }
        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            txtOUTPUT.Clear();
        }

        private void btnVIEWINFO_Click(object sender, EventArgs e)
        {
            if(cbALLUNIQUEENTRIES.SelectedIndex == -1)
            {
                txtOUTPUT.AppendText("\r\n[ERROR] NO ITEM SELECTED\r\n");
                return;
            }
            
            if(group_list.Count <= 0)
            {
                txtOUTPUT.AppendText("\r\n[ERROR] XML NOT LOADED\r\n");
                return;
            }

            txtOUTPUT.AppendText("\r\n**********************************************************");
            txtOUTPUT.AppendText("\r\n******** VIEWING INFO FOR " + cbALLUNIQUEENTRIES.SelectedItem.ToString());

            int finding_num = 0;
            for (int i = 0; i < group_list.Count; ++i)
            {
                if(group_list[i].name == cbALLUNIQUEENTRIES.SelectedItem.ToString())
                {
                    finding_num += 1;
                    if (finding_num < 10) txtOUTPUT.AppendText("\r\n[ITEM 0");
                    else txtOUTPUT.AppendText("\r\n[ITEM ");

                    txtOUTPUT.AppendText(finding_num.ToString() + "] Name = " + group_list[i].name + " || pos = " + group_list[i].pos + " || rpy = " + group_list[i].rpy + " || a = " + group_list[i].a);
                }
            }

            if(cbALLUNIQUEMAPENTRIES.SelectedIndex == -1)
            {
                txtOUTPUT.AppendText("\r\n[ERROR] NO ITEM SELECTED\r\n");
                return;
            }
            
            if(map_list.Count <= 0)
            {
                txtOUTPUT.AppendText("\r\n[ERROR] XML NOT LOADED\r\n");
                return;
            }

            txtOUTPUT.AppendText("\r\n**********************************************************");
            txtOUTPUT.AppendText("\r\n******** VIEWING INFO FOR " + cbALLUNIQUEMAPENTRIES.SelectedItem.ToString());

            finding_num = 0;
            for (int j = 0; j < map_list.Count; ++j)
            {
                if(map_list[j].mapname == cbALLUNIQUEMAPENTRIES.SelectedItem.ToString())
                {
                    finding_num += 1;
                    if (finding_num < 10) txtOUTPUT.AppendText("\r\n[ITEM 0");
                    else txtOUTPUT.AppendText("\r\n[ITEM ");

                    txtOUTPUT.AppendText(finding_num.ToString() + "] Name = " + map_list[j].mapname + " || pos = " + map_list[j].mappos);
                }
            }
        }

        public List<double> splitXYZ(string location)
        {
            List<double> result = new List<double>(); // result is X,Z,Y (How DayZ Coords are Written.)

            int foundpos = 0;
            int currentpos = 0;
            //string searchstring = gps.mappos;
            string tempposx = "";
            string tempposy = "";
            string tempposz = "";
            int count = 0;

            while (true)
            {
                foundpos = location.IndexOf(" ", currentpos);
                if (foundpos == -1) break;

                if (count == 0)
                {
                    tempposx = location.Substring(currentpos, (foundpos) - currentpos);
                    double.TryParse(tempposx, out double posx);
                    result.Add(posx);
                }
                else if (count == 1)
                {
                    tempposz = location.Substring(currentpos, (foundpos) - currentpos);
                    tempposy = location.Substring(foundpos);
                    double.TryParse(tempposz, out double posz);
                    double.TryParse(tempposy, out double posy);
                    result.Add(posz);
                    result.Add(posy);
                }
                else if (count == 2)
                {
                    tempposy = location.Substring(currentpos);
                }
                currentpos = foundpos + 1;
                count++;
            }
            return result;
        }

        public void viewCityInfo()
        {

            if (!int.TryParse(txtRADIUS.Text, out int radius))
            {
                txtOUTPUT.AppendText("\r\n^----^ QUIT FUCKING AROUND!!!!");
                return;
            }

            string currentcity = cbALLUNIQUEMAPENTRIES.SelectedItem.ToString();
            string currentmodel = cbALLUNIQUEENTRIES.SelectedItem.ToString();
            txtOUTPUT.AppendText("\r\nCurrently Selected Name = " + currentcity);
            bool found = false;

            foreach (var gps in map_list)
            {
                if (gps.mapname == currentcity)
                {
                    List<double> map_coords = splitXYZ(gps.mappos);
                    double map_x = map_coords[0];
                    double map_z = map_coords[1];
                    double map_y = map_coords[2];

                    txtOUTPUT.AppendText("\r\nFor Town " + currentcity + " X = " + map_x + " Z = " + map_z + " Y = " + map_y );

                    foreach (var model in group_list)
                    {
                        List<double> model_coords = new List<double>();
                        model_coords = splitXYZ(model.pos);
                        double model_x = model_coords[0];
                        double model_z = model_coords[1];
                        double model_y = model_coords[2];

                        if ((model.name.Trim() == currentmodel.Trim()) && ((map_x < model_x + radius ) && (map_x > model_x - radius)) && ((map_y < model_y + radius) && (map_y > model_y - radius)))
                        {
                            found = true;
                            txtOUTPUT.AppendText("\r\nWe have found: " + currentmodel + " in " + currentcity);
                            txtOUTPUT.AppendText("\r\nFor Model " + model.name + " X = " + model_x + " Z = " + model_z + " Y = " + model_y);
                        }
                    }
                }
            }
            if(!found) txtOUTPUT.AppendText("\r\nuWU Im sorry. You didnt say the Magic word." );
        }

        private void btnGENSPECIFIC_Click(object sender, EventArgs e)
        {
            if (cbALLUNIQUEENTRIES.SelectedIndex == -1)
            {
                txtOUTPUT.AppendText("\r\n[ERROR] NO ITEM SELECTED\r\n");
                return;
            }

            if (group_list.Count <= 0)
            {
                txtOUTPUT.AppendText("\r\n[ERROR] XML NOT LOADED\r\n");
                return;
            }

            if (cbALLUNIQUEMAPENTRIES.SelectedIndex == -1)
            {
                txtOUTPUT.AppendText("\r\n[ERROR] NO ITEM SELECTED\r\n");
                return;
            }

            if (map_list.Count <= 0)
            {
                txtOUTPUT.AppendText("\r\n[ERROR] XML NOT LOADED\r\n");
                return;
            }

            txtOUTPUT.Clear();

            List<string> full_output = new List<string>();

            string firstline = "if ( MBuilding == \"" + cbALLUNIQUEENTRIES.SelectedItem.ToString().Trim() + "\" )\r\n{\r\n";
            full_output.Add(firstline);

            int placeholder_count = 0;
            for (int i = 0; i < group_list.Count; ++i)
            {
                if (group_list[i].name == cbALLUNIQUEENTRIES.SelectedItem.ToString())
                {
                    placeholder_count += 1;
                    if(placeholder_count == 1)
                    {
                        string curr_line = "    if ( MLocation == \"PLACEHOLDER" + placeholder_count.ToString() + "\" )          BuildingPosList.Insert(\"" + group_list[i].pos + "\");\r\n";
                        full_output.Add(curr_line);
                    }
                    else
                    {
                        string curr_line = "    else if ( MLocation == \"PLACEHOLDER" + placeholder_count.ToString() + "\" )   BuildingPosList.Insert(\"" + group_list[i].pos + "\");\r\n";
                        full_output.Add(curr_line);
                    }
                }
            }

            if(placeholder_count > 0)
            {
                string end_line = "    else return false;  // no match for MLocation\r\n}\r\n\r\n";
                full_output.Add(end_line);
            }

            // print code to textbox
            // (can also use this to output to file)
            for(int i = 0; i < full_output.Count; ++i)
            {
                txtOUTPUT.AppendText(full_output[i]);
            }
        }

        private async void btnALLTHETHINGS_Click(object sender, EventArgs e)
        {
            if (group_list.Count <= 0)
            {
                txtOUTPUT.AppendText("\r\n[ERROR] XML NOT LOADED\r\n");
                return;
            }

            txtOUTPUT.Clear();

            List<string> full_output = new List<string>();
            int minor_count = 0;
            int major_count = 0;

            for (int j = 0; j < unique_model_name_list.Count; ++j)
            {
                string curr_line = "";
                if (major_count == 0) // first line does not have "else"
                {
                    curr_line = "if ( MBuilding == \"" + unique_model_name_list[j] + "\" )\r\n{";
                    full_output.Add(curr_line);
                }
                else
                {
                    curr_line = "else if ( MBuilding == \"" + unique_model_name_list[j] + "\" )\r\n{";
                    full_output.Add(curr_line);
                }

                curr_line = "";

                for (int i = 0; i < group_list.Count; ++i)
                {
                    if(group_list[i].name == unique_model_name_list[j])
                    {
                        minor_count += 1;
                        if (minor_count == 1)
                        {
                            curr_line = "    if ( MLocation == \"PLACEHOLDER" + minor_count.ToString() + "\" )          BuildingPosList.Insert(\"" + group_list[i].pos + "\");";
                            full_output.Add(curr_line);
                        }
                        else
                        {
                            curr_line = "    else if ( MLocation == \"PLACEHOLDER" + minor_count.ToString() + "\" )   BuildingPosList.Insert(\"" + group_list[i].pos + "\");";
                            full_output.Add(curr_line);
                        }
                    }
                }

                if (minor_count > 0)
                {
                    string this_line = "    else return false;  // no match for MLocation";
                    full_output.Add(this_line);
                }

                full_output.Add("}");

                major_count += 1;
                minor_count = 0;
            }

            string end_line = "else { /* MBuilding not found */ }";
            full_output.Add(end_line);

            await File.WriteAllLinesAsync("output_code.cpp", full_output.ToArray());

            txtOUTPUT.AppendText("\r\n[INFO] FINISHED WRITING CODE TO file 'output_code.cpp'!");
        }

        private void btnVIEWCITYINFO_MouseClick(object sender, MouseEventArgs e)
        {
            viewCityInfo();
        }
    }
}