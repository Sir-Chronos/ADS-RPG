using Godot;
using System;

public partial class Archer : BaseCharacter
{
  public Archer(int level, int xp, int baseXp)
      : base(10, 10, 8, 6, 12, 4, 10, 10, level, xp, baseXp)
  {
    Profession = "Arqueiro";
    Title = "O Preciso";
  }

  public override void BasicAttack(BaseCharacter target)
  {
    // Causar dano físico ao alvo
    int damage = Attack; // Dano base
    target.TakeDamage(damage, DamageType.Physical);
    GD.Print($"{Title} ataca {target.Title} causando {damage} de dano físico.");
  }

  public override void SpecialAttack(BaseCharacter target)
  {
    // Um ataque especial que causa dano aumentado
    int damage = Attack * 2; // Dano dobrado
    target.TakeDamage(damage, DamageType.Physical);
    GD.Print($"{Title} realiza um ataque especial em {target.Title} causando {damage} de dano físico.");
  }

  public override void UtilitySpell()
  {
    // Aumenta a agilidade temporariamente
    Agility += 3; // Aumenta a agilidade em 3
    GD.Print($"{Title} aumenta sua agilidade em 3.");
  }
}
