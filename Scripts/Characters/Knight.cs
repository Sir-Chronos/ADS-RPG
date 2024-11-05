using Godot;
using System;

public partial class Knight : BaseCharacter
{
  public Knight(int level, int xp, int baseXp)
      : base(15, 6, 18, 14, 12, 5, 7, 5, level, xp, baseXp)
  {
    Profession = "Cavaleiro";
    Title = "O Bravo";
  }

  public override void BasicAttack(BaseCharacter target)
  {
    int damage = Attack; // Dano do ataque básico
    target.TakeDamage(damage, DamageType.Physical); // Aplica o dano ao alvo
    GD.Print($"{Title} ataca {target.Title} causando {damage} de dano físico."); // Imprime a ação
  }

  public override void SpecialAttack(BaseCharacter target)
  {
    int damage = (int)(MagicAttack * 1.5); // Exemplo: ataque especial causa 1.5 vezes o dano mágico
    target.TakeDamage(damage, DamageType.Magical); // Aplica o dano ao alvo
    GD.Print($"{Title} usa um ataque especial em {target.Title} causando {damage} de dano mágico."); // Imprime a ação
  }

  public override void UtilitySpell()
  {
    // Exemplo: habilidade de cura que restaura 10% da saúde base do cavaleiro
    int healAmount = (int)(BaseHealth * 0.1); // Cura 10% da saúde base do cavaleiro
    Health += healAmount; // Restaura a saúde do cavaleiro
    GD.Print($"{Title} se cura, restaurando {healAmount} de saúde."); // Imprime a ação
  }
}
