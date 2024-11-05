using Godot;
using System;

public partial class Skeleton : BaseCharacter
{
  public Skeleton(int level, int xp, int baseXp)
      : base(8, 8, 8, 6, 10, 6, 8, 5, level, xp, baseXp)
  {
    Profession = "Esqueleto";
    Title = "O Imortal";
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
    // Um ataque que causa dano e ignora parte da defesa do alvo
    int damage = Attack * 2; // Dano dobrado
    target.TakeDamage(damage, DamageType.Physical);
    GD.Print($"{Title} realiza um ataque especial em {target.Title} causando {damage} de dano físico.");
  }

  public override void UtilitySpell()
  {
    // Aumenta a defesa por um turno
    Defense += 5;
    GD.Print($"{Title} aumenta sua defesa em 5.");
  }
}
