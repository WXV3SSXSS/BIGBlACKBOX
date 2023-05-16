using System.Drawing;
using System.Windows.Forms;

namespace BIGBlACKBOX
{
	public partial class Form1 : Form
	{
		int n1, n2, n3;
		Random random= new Random();
		int L;
		int N = 40;
		List<Particle> particles = new List<Particle>();

		private void timer1_Tick(object sender, EventArgs e)
		{
			GenerateNewValue();
			Draw();
		}

		private void Draw()
		{
			Graphics gr;
			Bitmap bmp;
			bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			gr = Graphics.FromImage(bmp);

			foreach (var p in particles)
			{
				Color color1 = Color.FromArgb((int)(255 * p.value), (int)(255 * p.value), (int)(255 * p.value));
				var brush = new SolidBrush(color1);
				gr.FillEllipse(brush, (int)p.x, (int)p.y, L, L);
			}

			pictureBox1.Image = bmp;
		}

		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				n1 = Convert.ToInt32(textBox1.Text);
				n2 = Convert.ToInt32(textBox2.Text);
				n3 = Convert.ToInt32(textBox3.Text);
				L = pictureBox1.Height / N;
			}
			catch (Exception exp)
			{
				MessageBox.Show(exp.Message + "\nОшибка конвертации напишит корректное число");
			}
			finally
			{
				timer1.Start();
				//kek();
				//Draw();
			}
		}

		public void GenerateNewValue()
		{
			var xNow = random.NextDouble(); 
			var sin1 = Math.Sin(n1 * Math.PI * xNow);

			var yNow = random.NextDouble();
			var sin2 = Math.Sin(n2 * Math.PI * yNow);

			var zNow = random.NextDouble();
			var sin3 = Math.Sin(n3 * Math.PI * zNow);
			particles.Add(new Particle()
			{
				x = xNow * L * N,
		        y = yNow * L * N,
				value = (sin1 * sin2) * (sin1 * sin2)
			});
		}


		//dont use
		public void kek()
		{
			int x = 0;
			int y = 0; 
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < N; j++)
				{
					x += L;
					var sin1 = Math.Sin(n1 * Math.PI * x / L);
					var sin2 = Math.Sin(n2 * Math.PI * y / L);
					particles.Add(new Particle()
					{
						x = x,
						y = y,
						value = (sin1 * sin2) * (sin1 * sin2)
					});
				}
				y += L;
				x = 0;
			}
		}
	}
}