﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork2
{
    public class ShopManager
    {
        public List<Artifact> Artifacts { get; } = new List<Artifact>();

        public void LoadAllData()
        {
            LegendaryProcessor legendaryProcessor = new LegendaryProcessor();
            JsonProcessor jsonProcessor = new JsonProcessor();
            XmlProcessor xmlProcessor = new XmlProcessor();

            try
            {
                LoadProcessorData(new XmlProcessor(), "antique.xml");
                LoadProcessorData(new JsonProcessor(), "modern.json");
                LoadProcessorData(new LegendaryProcessor(), "legendary.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void GenerateReport()
        {

        }

        public List<LegendaryArtifact> FindCursedArtifacts()
        {
            try
            {
                return Artifacts.OfType<LegendaryArtifact>()
                .Where(a => a.IsCursed && a.PowerLevel > 50)
                .ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Dictionary<Artifact.Rarity, int> GroupByRarity()
        {
            try
            {
                return Artifacts.GroupBy(i => i.rarity)
                .ToDictionary(j => j.Key, j => j.Count());
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<Artifact> TopByPower(int count)
        {
            try
            {
                return Artifacts.OrderByDescending(i => i.PowerLevel).
                Take(count).
                ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }



        private void LoadProcessorData<T>(IDataProcessor<T> processor, string filePath) where T : Artifact
        {
            try
            {
                var data = processor.LoadData(filePath);
                if (data != null && data.Any())
                {
                    Artifacts.AddRange(data.Cast<Artifact>());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
