using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio2
{
    public partial class Form1 : Form
    {
        private Game game;
        private Random random = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            game = new Game(new Rectangle(78, 57, 420, 155));
            game.NewLevel(random);
            UpdateCharacteres();
        }

        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// "Armas selecionas"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bagSword_Click(object sender, EventArgs e)
        {
            //ChekPlayerInventory() -- resolvi controlart pelo enable... quando pegar mudar para true
                //game.Equip
                //borderstyle --> single e remove dos outros

            //habilitar os outros 3 botoes e mudar beber para "Acima"
        }

        private void bagRedPotion_Click(object sender, EventArgs e)
        {
            //ChekPlayerInventory() -- resolvi controlart pelo enable... quando pegar mudar para true
            //game.Equip
            //borderstyle --> single e remove dos outros

            // se for uma opçcao deixar so o acima habilitado e com o texto de "Beber"

        }

        private void bagBow_Click(object sender, EventArgs e)
        {
            //ChekPlayerInventory() -- resolvi controlart pelo enable... quando pegar mudar para true
            //game.Equip
            //borderstyle --> single e remove dos outros

            //habilitar os outros 3 botoes e mudar beber para "Acima"
        }

        private void bagBluePotion_Click(object sender, EventArgs e)
        {
            //ChekPlayerInventory() -- resolvi controlart pelo enable... quando pegar mudar para true
            //game.Equip
            //borderstyle --> single e remove dos outros

            // se for uma opçcao deixar so o acima habilitado e com o texto de "Beber"

        }

        private void bagMace_Click(object sender, EventArgs e)
        {
            //ChekPlayerInventory() -- resolvi controlart pelo enable... quando pegar mudar para true
            //game.Equip
            //borderstyle --> single e remove dos outros

            //habilitar os outros 3 botoes e mudar beber para "Acima"

        }


        /// <summary>
        /// Movimentos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void moveAcima_Click(object sender, EventArgs e)
        {
            //chama game.move
            //updateCharacteres;
        }

        private void moveDireita_Click(object sender, EventArgs e)
        {
            //chama game.move
            //updateCharacteres;
        }

        private void moveEsquerda_Click(object sender, EventArgs e)
        {
            //chama game.move
            //updateCharacteres;
        }

        private void moveAbaixo_Click(object sender, EventArgs e)
        {
            //chama game.move
            //updateCharacteres;
        }




        /// <summary>
        /// ataques
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        
        private void ataqueAcima_Click(object sender, EventArgs e)
        {
            //game.ataque
            //updateCharacteres;
        }

        private void ataqueDireita_Click(object sender, EventArgs e)
        {
            //game.ataque
            //updateCharacteres;
        }

        private void ataqueEsquerda_Click(object sender, EventArgs e)
        {
            //game.ataque
            //updateCharacteres;
        }

        private void ataqueAbaixo_Click(object sender, EventArgs e)
        {
            //game.ataque
            //updateCharacteres;
        }


        public void UpdateCharacteres()
        {
            picJogador.Location = game.PlayerLocation;
            vidaJogador.Text = game.PlayerHitPoints.ToString();

            int enemiesShown = 0;

            //algum codigo


            foreach (Enemy enemy in game.Enemies)
            {
                if (enemy is Bat)
                {
                    picBat.Location = enemy.Location;
                    vidaMorcego.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        picBat.Visible = true;
                        enemiesShown++;
                    }
                    else
                    {
                        picBat.Visible = false;
                        vidaMorcego.Text = "";
                    }
                }
                if (enemy is Ghost)
                {
                    picGhost.Location = enemy.Location;
                    vidaFantasma.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        picGhost.Visible = true;
                        enemiesShown++;
                    }
                    else
                    {
                        picGhost.Visible = false;
                        vidaFantasma.Text = "";
                    }
                }
                if (enemy is Ghoul)
                {
                    picGhoul.Location = enemy.Location;
                    vidaZumbi.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        picGhoul.Visible = true;
                        enemiesShown++;
                    }
                    else
                    {
                        picGhoul.Visible = false;
                        vidaZumbi.Text = "";
                    }
                }
            }//fim foreach


            picSword.Visible = false;
            picBow.Visible = false;
            picRedPotion.Visible = false;
            picBluePotion.Visible = false;
            picMace.Visible = false;
            Control weaponControl = null;
            switch (game.WeaponInRoom.Name)
            {
                case "Sword":
                    weaponControl = picSword; 
                    break;
                case "Bow":
                    weaponControl = picBow;
                    break;
                case "Mace":
                    weaponControl = picMace;
                    break;
                case "RedPotion":
                    weaponControl = picRedPotion;
                    break;
                case "BluePotion":
                    weaponControl = picBluePotion;
                    break;
            }
            weaponControl.Visible = true;



            bagSword.Enabled = false;
            bagBow.Enabled = false;
            bagRedPotion.Enabled = false;
            bagBluePotion.Enabled = false;
            bagMace.Enabled = false;
            if(game.CheckPlayerInventory("Sword"))
                bagSword.Enabled = true;
            if (game.CheckPlayerInventory("Bow"))
                bagBow.Enabled = true;
            if (game.CheckPlayerInventory("Mace"))
                bagMace.Enabled = true;
            if (game.CheckPlayerInventory("RedPotion"))
                bagRedPotion.Enabled = true;
            if (game.CheckPlayerInventory("BluePotion"))
                bagBluePotion.Enabled = true;



            weaponControl.Location = game.WeaponInRoom.Location;
            weaponControl.Visible = (game.WeaponInRoom.PickedUp) ? false : true;

            if (game.PlayerHitPoints <= 0)
            {
                MessageBox.Show("Você morreu!", "Ha ha");
                Application.Exit();
            }
            if (enemiesShown < 1)
            {
                MessageBox.Show("Você derrotou todos os inimigos desse nível", "Continue assim.");
                game.NewLevel(random);
                UpdateCharacteres();
            }

        }




    }
}
