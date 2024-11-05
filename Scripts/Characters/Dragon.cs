using Godot;
using System;

public partial class Dragon : BaseCharacter
{
  public Dragon(int level, int xp, int baseXp)
      : base(14, 8, 16, 12, 18, 10, 12, 7, level, xp, baseXp)
  {
    Profession = "Dragão";
    Title = "O Feroz";
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
    // Um ataque em área que causa dano a todos os inimigos
    int damage = MagicAttack * 4; // Dano quadruplicado
    target.TakeDamage(damage, DamageType.Magical);
    GD.Print($"{Title} lança um ataque em área em {target.Title} causando {damage} de dano mágico.");
  }

  public override void UtilitySpell()
  {
    // Cura a si mesmo ou aumenta o ataque temporariamente
    int healAmount = 10;
    Health += healAmount;
    if (Health > BaseHealth)
    {
      Health = BaseHealth; // Não ultrapassar a saúde máxima
    }
    GD.Print($"{Title} se cura em {healAmount} pontos de saúde.");
  }
}
