using Godot;
using System;

public partial class Zombie : BaseCharacter
{
  public Zombie(int level, int xp, int baseXp)
      : base(10, 2, 12, 6, 8, 2, 4, 2, level, xp, baseXp)
  {
    Profession = "Zumbi";
    Title = "O Errante";
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
    // Um ataque que causa dano e pode reduzir a velocidade do alvo
    int damage = Attack; // Dano base
    target.TakeDamage(damage, DamageType.Physical);
    target.Speed -= 2; // Reduz a velocidade do alvo em 2
    GD.Print($"{Title} ataca {target.Title} causando {damage} de dano físico e reduzindo sua velocidade.");
  }

  public override void UtilitySpell()
  {
    // Zumbis podem se curar a si mesmos
    int healAmount = 5;
    Health += healAmount;
    if (Health > BaseHealth)
    {
      Health = BaseHealth; // Não ultrapassar a saúde máxima
    }
    GD.Print($"{Title} se cura em {healAmount} pontos de saúde.");
  }
}