namespace JuncCap
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.numericUpDownEg = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownEf = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownThickness = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownVbi = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.numericUpDownFreq = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownT = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDV = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBias = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxCap = new System.Windows.Forms.TextBox();
            this.buttonRunDlcp = new System.Windows.Forms.Button();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVbi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea8.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chart1.Legends.Add(legend8);
            this.chart1.Location = new System.Drawing.Point(282, 12);
            this.chart1.Name = "chart1";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.chart1.Series.Add(series8);
            this.chart1.Size = new System.Drawing.Size(437, 300);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // numericUpDownEg
            // 
            this.numericUpDownEg.DecimalPlaces = 3;
            this.numericUpDownEg.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownEg.Location = new System.Drawing.Point(124, 38);
            this.numericUpDownEg.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownEg.Name = "numericUpDownEg";
            this.numericUpDownEg.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownEg.TabIndex = 1;
            this.numericUpDownEg.Value = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            this.numericUpDownEg.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            // 
            // numericUpDownEf
            // 
            this.numericUpDownEf.DecimalPlaces = 3;
            this.numericUpDownEf.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownEf.Location = new System.Drawing.Point(124, 64);
            this.numericUpDownEf.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownEf.Name = "numericUpDownEf";
            this.numericUpDownEf.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownEf.TabIndex = 2;
            this.numericUpDownEf.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownEf.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            // 
            // numericUpDownThickness
            // 
            this.numericUpDownThickness.DecimalPlaces = 3;
            this.numericUpDownThickness.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownThickness.Location = new System.Drawing.Point(124, 90);
            this.numericUpDownThickness.Name = "numericUpDownThickness";
            this.numericUpDownThickness.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownThickness.TabIndex = 3;
            this.numericUpDownThickness.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownThickness.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            // 
            // numericUpDownVbi
            // 
            this.numericUpDownVbi.DecimalPlaces = 3;
            this.numericUpDownVbi.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownVbi.Location = new System.Drawing.Point(124, 116);
            this.numericUpDownVbi.Name = "numericUpDownVbi";
            this.numericUpDownVbi.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownVbi.TabIndex = 4;
            this.numericUpDownVbi.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownVbi.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.DecimalPlaces = 3;
            this.numericUpDown5.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown5.Location = new System.Drawing.Point(124, 142);
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown5.TabIndex = 5;
            this.numericUpDown5.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown5.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Bandgap [eV]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Fermi Level [eV]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Thickness [μm]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Built-in Voltage [V]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Dielectric Constant";
            // 
            // chart2
            // 
            chartArea9.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea9);
            legend9.Name = "Legend1";
            this.chart2.Legends.Add(legend9);
            this.chart2.Location = new System.Drawing.Point(282, 318);
            this.chart2.Name = "chart2";
            series9.ChartArea = "ChartArea1";
            series9.Legend = "Legend1";
            series9.Name = "Series1";
            this.chart2.Series.Add(series9);
            this.chart2.Size = new System.Drawing.Size(437, 300);
            this.chart2.TabIndex = 11;
            this.chart2.Text = "chart2";
            // 
            // numericUpDownFreq
            // 
            this.numericUpDownFreq.DecimalPlaces = 3;
            this.numericUpDownFreq.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownFreq.Location = new System.Drawing.Point(124, 286);
            this.numericUpDownFreq.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDownFreq.Name = "numericUpDownFreq";
            this.numericUpDownFreq.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownFreq.TabIndex = 12;
            this.numericUpDownFreq.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownFreq.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            // 
            // numericUpDownT
            // 
            this.numericUpDownT.DecimalPlaces = 3;
            this.numericUpDownT.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownT.Location = new System.Drawing.Point(124, 260);
            this.numericUpDownT.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownT.Name = "numericUpDownT";
            this.numericUpDownT.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownT.TabIndex = 13;
            this.numericUpDownT.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numericUpDownT.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            // 
            // numericUpDownDV
            // 
            this.numericUpDownDV.DecimalPlaces = 3;
            this.numericUpDownDV.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownDV.Location = new System.Drawing.Point(124, 234);
            this.numericUpDownDV.Name = "numericUpDownDV";
            this.numericUpDownDV.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownDV.TabIndex = 14;
            this.numericUpDownDV.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownDV.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            // 
            // numericUpDownBias
            // 
            this.numericUpDownBias.DecimalPlaces = 3;
            this.numericUpDownBias.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownBias.Location = new System.Drawing.Point(124, 208);
            this.numericUpDownBias.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownBias.Name = "numericUpDownBias";
            this.numericUpDownBias.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownBias.TabIndex = 15;
            this.numericUpDownBias.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Bias [V]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "AC perturbation [mV]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 262);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Temperature [K]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 288);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Frequency [Hz]";
            // 
            // textBoxCap
            // 
            this.textBoxCap.Enabled = false;
            this.textBoxCap.Location = new System.Drawing.Point(124, 333);
            this.textBoxCap.Name = "textBoxCap";
            this.textBoxCap.Size = new System.Drawing.Size(120, 20);
            this.textBoxCap.TabIndex = 21;
            // 
            // buttonRunDlcp
            // 
            this.buttonRunDlcp.Location = new System.Drawing.Point(1302, 12);
            this.buttonRunDlcp.Name = "buttonRunDlcp";
            this.buttonRunDlcp.Size = new System.Drawing.Size(75, 23);
            this.buttonRunDlcp.TabIndex = 22;
            this.buttonRunDlcp.Text = "Run DLCP";
            this.buttonRunDlcp.UseVisualStyleBackColor = true;
            this.buttonRunDlcp.Click += new System.EventHandler(this.buttonRunDlcp_Click);
            // 
            // chart3
            // 
            chartArea10.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea10);
            legend10.Name = "Legend1";
            this.chart3.Legends.Add(legend10);
            this.chart3.Location = new System.Drawing.Point(859, 12);
            this.chart3.Name = "chart3";
            series10.ChartArea = "ChartArea1";
            series10.Legend = "Legend1";
            series10.Name = "Series1";
            this.chart3.Series.Add(series10);
            this.chart3.Size = new System.Drawing.Size(437, 300);
            this.chart3.TabIndex = 23;
            this.chart3.Text = "chart3";
            // 
            // chart4
            // 
            chartArea11.Name = "ChartArea1";
            this.chart4.ChartAreas.Add(chartArea11);
            legend11.Name = "Legend1";
            this.chart4.Legends.Add(legend11);
            this.chart4.Location = new System.Drawing.Point(859, 318);
            this.chart4.Name = "chart4";
            series11.ChartArea = "ChartArea1";
            series11.Legend = "Legend1";
            series11.Name = "Series1";
            this.chart4.Series.Add(series11);
            this.chart4.Size = new System.Drawing.Size(437, 300);
            this.chart4.TabIndex = 24;
            this.chart4.Text = "chart4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1599, 680);
            this.Controls.Add(this.chart4);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.buttonRunDlcp);
            this.Controls.Add(this.textBoxCap);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDownBias);
            this.Controls.Add(this.numericUpDownDV);
            this.Controls.Add(this.numericUpDownT);
            this.Controls.Add(this.numericUpDownFreq);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown5);
            this.Controls.Add(this.numericUpDownVbi);
            this.Controls.Add(this.numericUpDownThickness);
            this.Controls.Add(this.numericUpDownEf);
            this.Controls.Add(this.numericUpDownEg);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVbi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.NumericUpDown numericUpDownEg;
        private System.Windows.Forms.NumericUpDown numericUpDownEf;
        private System.Windows.Forms.NumericUpDown numericUpDownThickness;
        private System.Windows.Forms.NumericUpDown numericUpDownVbi;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.NumericUpDown numericUpDownFreq;
        private System.Windows.Forms.NumericUpDown numericUpDownT;
        private System.Windows.Forms.NumericUpDown numericUpDownDV;
        private System.Windows.Forms.NumericUpDown numericUpDownBias;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxCap;
        private System.Windows.Forms.Button buttonRunDlcp;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart4;
    }
}

