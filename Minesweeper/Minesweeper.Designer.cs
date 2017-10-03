namespace Minesweeper
{
    partial class Minesweeper
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Minesweeper));
            this.performanceCounter1 = new System.Diagnostics.PerformanceCounter();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.newGameItem = new System.Windows.Forms.MenuItem();
            this.beginnerItem = new System.Windows.Forms.MenuItem();
            this.intermediateItem = new System.Windows.Forms.MenuItem();
            this.expertItem = new System.Windows.Forms.MenuItem();
            this.customItem = new System.Windows.Forms.MenuItem();
            this.bestTimesItem = new System.Windows.Forms.MenuItem();
            this.exitItem = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.newGameItem,
            this.beginnerItem,
            this.intermediateItem,
            this.expertItem,
            this.customItem,
            this.bestTimesItem,
            this.exitItem});
            this.menuItem1.Text = "Game";
            // 
            // newGameItem
            // 
            this.newGameItem.Index = 0;
            this.newGameItem.Text = "New";
            this.newGameItem.Click += new System.EventHandler(this.newGameItem_Click);
            // 
            // beginnerItem
            // 
            this.beginnerItem.Index = 1;
            this.beginnerItem.Text = "Beginner";
            this.beginnerItem.Click += new System.EventHandler(this.beginnerItem_Click);
            // 
            // intermediateItem
            // 
            this.intermediateItem.Index = 2;
            this.intermediateItem.Text = "Intermediate";
            this.intermediateItem.Click += new System.EventHandler(this.intermediateItem_Click);
            // 
            // expertItem
            // 
            this.expertItem.Index = 3;
            this.expertItem.Text = "Expert";
            this.expertItem.Click += new System.EventHandler(this.expertItem_Click);
            // 
            // customItem
            // 
            this.customItem.Index = 4;
            this.customItem.Text = "Custom...";
            this.customItem.Click += new System.EventHandler(this.customItem_Click);
            // 
            // bestTimesItem
            // 
            this.bestTimesItem.Index = 5;
            this.bestTimesItem.Text = "Best Times...";
            // 
            // exitItem
            // 
            this.exitItem.Index = 6;
            this.exitItem.Text = "Exit";
            this.exitItem.Click += new System.EventHandler(this.exitItem_Click);
            // 
            // Minesweeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "Minesweeper";
            this.Text = "Minesweeper";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Diagnostics.PerformanceCounter performanceCounter1;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem newGameItem;
        private System.Windows.Forms.MenuItem beginnerItem;
        private System.Windows.Forms.MenuItem intermediateItem;
        private System.Windows.Forms.MenuItem expertItem;
        private System.Windows.Forms.MenuItem customItem;
        private System.Windows.Forms.MenuItem bestTimesItem;
        private System.Windows.Forms.MenuItem exitItem;
    }
}

