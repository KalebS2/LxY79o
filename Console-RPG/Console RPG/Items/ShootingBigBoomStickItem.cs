namespace Console_RPG.Items
{
    class ShootingBigBoomStickItem : Item
    {
        public int damage;
        public int ammo;
        public ShootingBigBoomStickItem(string name, string description, int shopPrice, int sellPrice, int damage, int ammo) : base(name, description, shopPrice, sellPrice)
        {
            this.damage = damage;
            this.ammo = ammo;
        }

        public override void Use(Entity user, Entity target)
        {
            if (ammo == 0)
                return;

            target.currentHP -= damage;
            --ammo;
        }
    }
}

