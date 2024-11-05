using Godot;
using System;

public abstract partial class BaseCharacter : Node
{
  public string Profession { get; set; }
  public string Title { get; set; }

  public int BaseHealth { get; set; }
  public int BaseMana { get; set; }
  public int BaseDefense { get; set; }
  public int BaseMagicDefense { get; set; }
  public int BaseAttack { get; set; }
  public int BaseMagicAttack { get; set; }
  public int BaseSpeed { get; set; }
  public int BaseAgility { get; set; }

  public int Health { get; set; }
  public int Mana { get; set; }
  public int Defense { get; set; }
  public int MagicDefense { get; set; }
  public int Attack { get; set; }
  public int MagicAttack { get; set; }
  public int Speed { get; set; }
  public int Agility { get; set; }

  public int Level { get; set; }
  public int Xp { get; set; }
  public int BaseXp { get; set; }

  private RandomNumberGenerator rng = new RandomNumberGenerator();

  public enum DamageType
  {
    Physical,
    Magical
  }

  public BaseCharacter(int baseHealth, int baseMana, int baseDefense, int baseMagicDefense, int baseAttack, int baseMagicAttack, int baseSpeed, int baseAgility, int level, int xp, int baseXp)
  {
    BaseHealth = baseHealth;
    BaseMana = baseMana;
    BaseDefense = baseDefense;
    BaseMagicDefense = baseMagicDefense;
    BaseAttack = baseAttack;
    BaseMagicAttack = baseMagicAttack;
    BaseSpeed = baseSpeed;
    BaseAgility = baseAgility;

    Health = baseHealth;
    Mana = baseMana;
    Defense = baseDefense;
    MagicDefense = baseMagicDefense;
    Attack = baseAttack;
    MagicAttack = baseMagicAttack;
    Speed = baseSpeed;
    Agility = baseAgility;

    Level = level;
    Xp = xp;
    BaseXp = baseXp;

    rng.Randomize();
  }

  public abstract void BasicAttack(BaseCharacter target);
  public abstract void SpecialAttack(BaseCharacter target);
  public abstract void UtilitySpell();

  public virtual void Rest()
  {
    Health += (int)(BaseHealth * 0.3);
    Mana += BaseMana;
  }

  public virtual void TakeDamage(int damage, DamageType type)
  {
    if (!Dodge())
    {
      switch (type)
      {
        case DamageType.Physical:
          Health -= Math.Max(damage - Defense, 0);
          break;
        case DamageType.Magical:
          Health -= Math.Max(damage - MagicDefense, 0);
          break;
      }
    }
  }

  public virtual bool Dodge()
  {
    int roll = rng.RandiRange(0, 100);
    return Agility > roll;
  }

  public virtual void LevelUp()
  {
    if (Xp >= BaseXp)
    {
      Level++;
      Xp = 0;
      BaseXp = (int)(BaseXp * 1.5);

      ApplyLevelBonuses();
    }
  }

  public void ApplyLevelBonuses()
  {
    BaseHealth = (int)(BaseHealth * Math.Pow(1.2, Level - 1));
    BaseMana = (int)(BaseMana * Math.Pow(1.2, Level - 1));
    BaseDefense = (int)(BaseDefense * Math.Pow(1.2, Level - 1));
    BaseMagicDefense = (int)(BaseMagicDefense * Math.Pow(1.2, Level - 1));
    BaseAttack = (int)(BaseAttack * Math.Pow(1.2, Level - 1));
    BaseMagicAttack = (int)(BaseMagicAttack * Math.Pow(1.2, Level - 1));
    BaseSpeed = (int)(BaseSpeed * Math.Pow(1.2, Level - 1));
    BaseAgility = (int)(BaseAgility * Math.Pow(1.2, Level - 1));

    Health = BaseHealth;
    Mana = BaseMana;
    Defense = BaseDefense;
    MagicDefense = BaseMagicDefense;
    Attack = BaseAttack;
    MagicAttack = BaseMagicAttack;
    Speed = BaseSpeed;
    Agility = BaseAgility;
  }

  public virtual void GetXp(int amount)
  {
    Xp += amount;
    LevelUp();
  }
}
