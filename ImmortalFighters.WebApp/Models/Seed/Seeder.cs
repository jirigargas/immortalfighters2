using System.Collections.Generic;

namespace ImmortalFighters.WebApp.Models.Seed
{
    public class Seeder
    {
        private readonly IEnumerable<ISeeder> seeders;

        public Seeder(IEnumerable<ISeeder> seeders)
        {
            this.seeders = seeders;
        }

        public void Seed()
        {
            foreach (var seeder in seeders)
                seeder.Seed();
        }
    }
}
