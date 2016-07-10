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

        public Form1()
        {
            this.KeyPreview = true;
            this.KeyPress +=
                new KeyPressEventHandler(Form1_KeyPress);

            InitializeComponent();

            game = new Game(new Rectangle(89, 71, 420, 159));
            game.NewLevel(random);
            UpdateCharacteres();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game = new Game(new Rectangle(89, 71, 420, 159));
            game.NewLevel(random);
            UpdateCharacteres();
        }

       
        /// <summary>
        /// "Armas selecionas"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void resetButtons(){
            ataqueAcima.Text = "Acima";
            ataqueDireita.Enabled = true;
            ataqueEsquerda.Enabled = true;
            ataqueAbaixo.Enabled = true;
        }
        private void lockButtons()
        {
            ataqueAcima.Text = "Beber";
            ataqueDireita.Enabled = false;
            ataqueEsquerda.Enabled = false;
            ataqueAbaixo.Enabled = false;
        }
        private void bagSword_Click(object sender, EventArgs e)
        {
            resetButtons();
            if (game.CheckPlayerInventory("Sword"))
            {
                game.Equip("Sword");
                BorderWeaponSelected();
            }
        }

        private void bagRedPotion_Click(object sender, EventArgs e)
        {
            resetButtons();
            if (game.CheckPlayerInventory("RedPotion"))
            {
                game.Equip("RedPotion");
                BorderWeaponSelected();
                lockButtons();
            }

        }

        private void bagBow_Click(object sender, EventArgs e)
        {
            resetButtons();
            if (game.CheckPlayerInventory("Bow"))
            {
                game.Equip("Bow");
                BorderWeaponSelected();
            }
        }

        private void bagBluePotion_Click(object sender, EventArgs e)
        {
            resetButtons();
            if (game.CheckPlayerInventory("BluePotion"))
            {
                game.Equip("BluePotion");
                BorderWeaponSelected();
                lockButtons();
            }
        }

        private void bagMace_Click(object sender, EventArgs e)
        {
            resetButtons();
            if (game.CheckPlayerInventory("Mace"))
            {
                game.Equip("Mace");
                BorderWeaponSelected();
            }
        }


        /// <summary>
        /// Movimentos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void moveAcima_Click(object sender, EventArgs e)
        {
             game.Move(Mover.Direction.Up, random);
             UpdateCharacteres();             
        }

        private void moveDireita_Click(object sender, EventArgs e)
        {
            game.Move(Mover.Direction.Right, random);
            UpdateCharacteres();
        }

        private void moveEsquerda_Click(object sender, EventArgs e)
        {
            game.Move(Mover.Direction.Left, random);
            UpdateCharacteres();
        }

        private void moveAbaixo_Click(object sender, EventArgs e)
        {
            game.Move(Mover.Direction.Down, random);
            UpdateCharacteres();
        }




        /// <summary>
        /// ataques
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        
        private void ataqueAcima_Click(object sender, EventArgs e)
        {
            game.Attack(Mover.Direction.Up, random);
            UpdateCharacteres();
            resetButtons();
        }

        private void ataqueDireita_Click(object sender, EventArgs e)
        {
            game.Attack(Mover.Direction.Right, random);
            UpdateCharacteres();
        }

        private void ataqueEsquerda_Click(object sender, EventArgs e)
        {
            game.Attack(Mover.Direction.Left, random);
            UpdateCharacteres();
        }

        private void ataqueAbaixo_Click(object sender, EventArgs e)
        {
            game.Attack(Mover.Direction.Down, random);
            UpdateCharacteres();
        }

        public int updateEnemies()
        {
            int enemiesShown = 0;

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
            return  enemiesShown;
        }

        public void controleInventario()
        {
            bagSword.Visible = false;
            bagBow.Visible = false;
            bagRedPotion.Visible = false;
            bagBluePotion.Visible = false;
            bagMace.Visible = false;
            if (game.CheckPlayerInventory("Sword"))
                bagSword.Visible = true;
            if (game.CheckPlayerInventory("Bow"))
                bagBow.Visible = true;
            if (game.CheckPlayerInventory("Mace"))
                bagMace.Visible = true;
            if (game.CheckPlayerInventory("RedPotion"))
                bagRedPotion.Visible = true;
            if (game.CheckPlayerInventory("BluePotion"))
                bagBluePotion.Visible = true;
        }

        public void UpdateCharacteres()
        {
            if (game.Enemies.Count < 1)
            {
                MessageBox.Show("Você derrotou todos os inimigos do jogo!!! ", "WINNER");
                Application.Exit();
            }
            picJogador.Location = game.PlayerLocation;
            vidaJogador.Text = game.PlayerHitPoints.ToString();

            int enemiesShown = updateEnemies();
            
            controleInventario();

            BorderWeaponSelected();

            controleArma();

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

        private void controleArma()
        {
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
            
            weaponControl.Location = game.WeaponInRoom.Location;
            weaponControl.Visible = (game.WeaponInRoom.PickedUp) ? false : true;
        }

        private void BorderWeaponSelected()
        {
            if (game.WeaponEquiped != null)
            {
                bagSword.BorderStyle = BorderStyle.None;
                bagBow.BorderStyle = BorderStyle.None;
                bagMace.BorderStyle = BorderStyle.None;
                bagRedPotion.BorderStyle = BorderStyle.None;
                bagBluePotion.BorderStyle = BorderStyle.None;
                switch (game.WeaponEquiped)
                {
                    case "Sword":
                        bagSword.BorderStyle = BorderStyle.FixedSingle;
                        break;
                    case "Bow":
                        bagBow.BorderStyle = BorderStyle.FixedSingle;
                        break;
                    case "Mace":
                        bagMace.BorderStyle = BorderStyle.FixedSingle;
                        break;
                    case "RedPotion":
                        bagRedPotion.BorderStyle = BorderStyle.FixedSingle;
                        break;
                    case "BluePotion":
                        bagBluePotion.BorderStyle = BorderStyle.FixedSingle;
                        break;
                    default:
                        break;
                }
            }
        }

        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
            {
                MessageBox.Show("You pressed Left arrow key");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }



    }
}
