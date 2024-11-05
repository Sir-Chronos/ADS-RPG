using Godot;
using System;

public partial class Mage : BaseCharacter
{
  public Mage(int level, int xp, int baseXp)
      : base(9, 12, 4, 10, 5, 15, 6, 7, level, xp, baseXp)
  {
    Profession = "Mago";
    Title = "O Sábio";
  }

  public override void BasicAttack(BaseCharacter target)
  {
    // Causar dano mágico ao alvo
    int damage = MagicAttack; // Dano base
    target.TakeDamage(damage, DamageType.Magical);
    GD.Print($"{Title} ataca {target.Title} causando {damage} de dano mágico.");
  }

  public override void SpecialAttack(BaseCharacter target)
  {
    // Um ataque mágico que causa dano em área
    int damage = MagicAttack * 3; // Dano triplicado
    target.TakeDamage(damage, DamageType.Magical);
    GD.Print($"{Title} lança um ataque mágico em área em {target.Title} causando {damage} de dano mágico.");
  }

  public override void UtilitySpell()
  {
    // Restaura mana a si mesmo ou a um aliado
    int restoreAmount = 5;
    Mana += restoreAmount;
    GD.Print($"{Title} restaura {restoreAmount} de mana.");
  }
}
