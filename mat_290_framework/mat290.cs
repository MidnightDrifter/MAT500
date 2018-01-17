using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MathNet.Numerics;
namespace mat_290_framework
{

    public partial class MAT290 : Form
    {
        public MAT290()
        {
            InitializeComponent();

            pts_ = new List<Point2D>();
            tVal_ = 0.5F;
            degree_ = 0;
            knot_ = new List<float>();
            EdPtCont_ = true;
            rnd_ = new Random();
            polyDegree = 1;
       
            BinomialCoefTable = new List<List<int>>();
            updateP1DeCasteljauCoef = true;  //True if they DO need to be updated
            P1DecastlejauCoef = new List<List<Point2D>>();
            //
            for(int i=0;i<40;i++)
                {
                BinomialCoefTable.Add(new List<int>());
                P1DecastlejauCoef.Add(new List<Point2D>());
                for(int j=0;j<40;j++)
                    {
                    P1DecastlejauCoef[i].Add(new Point2D(INVALID_COEF,INVALID_COEF));
                    
                    if(i==0 )
                        {  
                            BinomialCoefTable[i].Add(0);   
                        }
                    else if( j == 0 || j == i)
                    {
                        BinomialCoefTable[i].Add(1);
                    }
                    else if (j==1 || j== i-1)
                        {
                            BinomialCoefTable[i].Add(i);
                        }
                    else
                        {
                            BinomialCoefTable[i].Add(-1);
                        }

                    }
                }




            BinomialCoefTable[0][0] = 1;

        }


       public int BinomialCoef(int x, int y)
            {
            int max = Math.Max(x, y);


            if(x==0)
            { return 1; }


            if (y > x)  //Invalid binomial coef, return -1
                {
                return -1;
                }


              
          
            else if(max > BinomialCoefTable.Capacity)
                {
                int currCapacity = BinomialCoefTable.Capacity;
                
                for(int i=currCapacity;i<max;i++)
                    {

                    if(i > currCapacity)   //Will need to fill in ALL of the vector--only fill it up to current capacity for now, though
                        {

                        BinomialCoefTable.Add(new List<int>());


                        for(int k=0;k<currCapacity;k++)
                                {
                                     if(k==0 || i==k)
                                        {  
                                            BinomialCoefTable[i].Add(0);   
                                        }
                                    else if(k==1 || i== k-1)
                                        {
                                            BinomialCoefTable[i].Add(i);
                                        }
                                    else
                                        {
                                            BinomialCoefTable[i].Add(-1);
                                        }


                                }


                        }
                        
                    for(int j=currCapacity;j<max;j++)
                        {

                        if(j>currCapacity)  
                            {
                            

                            if(j==0 || j==i)
                                {  
                                BinomialCoefTable[i].Add(0);   
                                }
                            else if(j==1 || j== i-1)
                                {
                                BinomialCoefTable[i].Add(i);
                                }
                            else
                                {
                                BinomialCoefTable[i].Add(-1);
                                }
                            

                            }


                        }



                    }




                }


            if(BinomialCoefTable[x][y] == -1)
                {
                 BinomialCoefTable[x][y] = BinomialCoef(x-1,y) + BinomialCoef(x-1,y-1);
                }
            else
                {
                return BinomialCoefTable[x][y];
                }
            return -1;
            }





       


        // Point class for general math use
        protected class Point2D : System.Object
        {
            public float x;
            public float y;

            public Point2D(float _x, float _y)
            {
                x = _x;
                y = _y;
            }

            public Point2D(Point2D rhs)
            {
                x = rhs.x;
                y = rhs.y;
            }

            // adds two points together; used for barycentric combos
            public static Point2D operator +(Point2D lhs, Point2D rhs)
            {
                return new Point2D(lhs.x + rhs.x, lhs.y + rhs.y);
            }

            // gets a distance between two points. not actual distance; used for picking
            public static float operator %(Point2D lhs, Point2D rhs)
            {
                float dx = (lhs.x - rhs.x);
                float dy = (lhs.y - rhs.y);

                return (dx * dx + dy * dy);
            }

            // scalar multiplication of points; for barycentric combos
            public static Point2D operator *(float t, Point2D rhs)
            {
                return new Point2D(rhs.x * t, rhs.y * t);
            }

            // scalar multiplication of points; for barycentric combos
            public static Point2D operator *(Point2D rhs, float t)
            {
                return new Point2D(rhs.x * t, rhs.y * t);
            }

            // returns the drawing subsytems' version of a point for drawing.
            public System.Drawing.Point P()
            {
                return new System.Drawing.Point((int)x, (int)y);
            }
        };

        List<Point2D> pts_; // the list of points used in internal algthms
        float tVal_; // t-value used for shell drawing
        int degree_; // degree of deboor subsplines
        List<float> knot_; // knot sequence for deboor
        bool EdPtCont_; // end point continuity flag for std knot seq contruction
        Random rnd_; // random number generator



        //PROJECT 1
        List<List<int>> BinomialCoefTable;
        bool updateP1DeCasteljauCoef;  //True if they DO need to be updated
        List<List<Point2D>> P1DecastlejauCoef;
        int polyDegree;


        // pickpt returns an index of the closest point to the passed in point
        //  -- usually a mouse position
        private int PickPt(Point2D m)
        {
            float closest = m % pts_[0];
            int closestIndex = 0;

            for (int i = 1; i < pts_.Count; ++i)
            {
                float dist = m % pts_[i];
                if (dist < closest)
                {
                    closest = dist;
                    closestIndex = i;
                }
            }

            return closestIndex;
        }

        private void Menu_Clear_Click(object sender, EventArgs e)
        {
            pts_.Clear();
            Refresh();
        }

        private void Menu_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MAT290_MouseMove(object sender, MouseEventArgs e)
        {
            // if the right mouse button is being pressed
            if (pts_.Count != 0 && e.Button == MouseButtons.Right)
            {
                // grab the closest point and snap it to the mouse
                if (Menu_Project1.Checked)
                {
                    int index = PickPt(new Point2D(e.X, e.Y));
                    //Want x coord to be static & only move y coord
                   // pts_[index].x = e.X;
                    pts_[index].y = e.Y;

                    Refresh();
                }

                // grab the closest point and snap it to the mouse
                else
                {
                    int index = PickPt(new Point2D(e.X, e.Y));

                    pts_[index].x = e.X;
                    pts_[index].y = e.Y;

                    Refresh();
                }
            }
        }

        private void MAT290_MouseDown(object sender, MouseEventArgs e)
        {
            // if the left mouse button was clicked
            if (e.Button == MouseButtons.Left)
            {
                // add a new point to the controlPoints
                if (!Menu_Project1.Checked)
                {
                    pts_.Add(new Point2D(e.X, e.Y));
                }

                if (Menu_DeBoor.Checked)
                {
                    ResetKnotSeq();
                    UpdateKnotSeq();
                }

                Refresh();
            }

            // if there are points and the middle mouse button was pressed
            if (pts_.Count != 0 && e.Button == MouseButtons.Middle && !Menu_Project1.Checked)
            {
                // then delete the closest point
                int index = PickPt(new Point2D(e.X, e.Y));

                pts_.RemoveAt(index);

                if (Menu_DeBoor.Checked)
                {
                    ResetKnotSeq();
                    UpdateKnotSeq();
                }

                Refresh();
            }
        }

        private void MAT290_MouseWheel(object sender, MouseEventArgs e)
        {
            // if the mouse wheel has moved
            if (e.Delta != 0)
            {
                // change the t-value for shell
                tVal_ += e.Delta / 120 * .02f;

                // handle edge cases
                tVal_ = (tVal_ < 0) ? 0 : tVal_;
                tVal_ = (tVal_ > 1) ? 1 : tVal_;

                Refresh();
            }
        }

        private void NUD_degree_ValueChanged(object sender, EventArgs e)
        {
            if (pts_.Count == 0)
                return;

            degree_ = (int)NUD_degree.Value;

            ResetKnotSeq();
            UpdateKnotSeq();

            NUD_degree.Value = degree_;

            Refresh();
        }

        private void CB_cont_CheckedChanged(object sender, EventArgs e)
        {
            EdPtCont_ = CB_cont.Checked;

            ResetKnotSeq();
            UpdateKnotSeq();

            Refresh();
        }

        private void Txt_knot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || e.KeyChar == '\n')
            {
                // update knot seq
                string[] splits = Txt_knot.Text.ToString().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                if (splits.Length > pts_.Count + degree_ + 1)
                    return;

                knot_.Clear();
                foreach (string split in splits)
                {
                    knot_.Add(Convert.ToSingle(split));
                }

                for (int i = knot_.Count; i < (pts_.Count + degree_ + 1); ++i)
                    knot_.Add((float)(i - degree_));

                UpdateKnotSeq();
            }

            Refresh();
        }

        private void Menu_Polyline_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Menu_Points_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Menu_Shell_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Menu_DeCast_Click(object sender, EventArgs e)
        {
            Menu_DeCast.Checked = !Menu_DeCast.Checked;
            Menu_Bern.Checked = false;
            Menu_Midpoint.Checked = false;

            Menu_Inter_Poly.Checked = false;
            Menu_Inter_Splines.Checked = false;

            Menu_DeBoor.Checked = false;

            Menu_Polyline.Enabled = true;
            Menu_Points.Enabled = true;
            Menu_Shell.Enabled = true;

            ToggleDeBoorHUD(false);

            Refresh();
        }

        private void Menu_Bern_Click(object sender, EventArgs e)
        {
            Menu_DeCast.Checked = false;
            Menu_Bern.Checked = !Menu_Bern.Checked;
            Menu_Midpoint.Checked = false;

            Menu_Inter_Poly.Checked = false;
            Menu_Inter_Splines.Checked = false;

            Menu_DeBoor.Checked = false;

            Menu_Polyline.Enabled = true;
            Menu_Points.Enabled = true;
            Menu_Shell.Enabled = true;

            ToggleDeBoorHUD(false);

            Refresh();
        }

        private void Menu_Midpoint_Click(object sender, EventArgs e)
        {
            Menu_DeCast.Checked = false;
            Menu_Bern.Checked = false;
            Menu_Midpoint.Checked = !Menu_Midpoint.Checked;

            Menu_Inter_Poly.Checked = false;
            Menu_Inter_Splines.Checked = false;

            Menu_DeBoor.Checked = false;

            Menu_Polyline.Enabled = true;
            Menu_Points.Enabled = true;
            Menu_Shell.Enabled = true;

            ToggleDeBoorHUD(false);

            Refresh();
        }


        private void Menu_Project1_Click(object sender, EventArgs e)
        {
            Menu_Project1.Checked = !Menu_Project1.Checked;
            Menu_Project2.Checked = false;
            Menu_Project3.Checked = false;
            Menu_Project4.Checked = false;
            Menu_Project5.Checked = false;
            Menu_Project6.Checked = false;
            Menu_Project7.Checked = false;
            Menu_Project8.Checked = false;
        }

        private void Menu_Project2_Click(object sender, EventArgs e)
        {
            Menu_Project1.Checked = false;
            Menu_Project2.Checked = !Menu_Project2.Checked;
            Menu_Project3.Checked = false;
            Menu_Project4.Checked = false;
            Menu_Project5.Checked = false;
            Menu_Project6.Checked = false;
            Menu_Project7.Checked = false;
            Menu_Project8.Checked = false;
        }

        private void Menu_Project3_Click(object sender, EventArgs e)
        {
            Menu_Project1.Checked = false;
            Menu_Project2.Checked = false;
            Menu_Project3.Checked = !Menu_Project3.Checked;
            Menu_Project4.Checked = false;
            Menu_Project5.Checked = false;
            Menu_Project6.Checked = false;
            Menu_Project7.Checked = false;
            Menu_Project8.Checked = false;
        }

        private void Menu_Project4_Click(object sender, EventArgs e)
        {
            Menu_Project1.Checked = !Menu_Project1.Checked;
            Menu_Project2.Checked = false;
            Menu_Project3.Checked = false;
            Menu_Project4.Checked = !Menu_Project4.Checked;
            Menu_Project5.Checked = false;
            Menu_Project6.Checked = false;
            Menu_Project7.Checked = false;
            Menu_Project8.Checked = false;
        }

        private void Menu_Project5_Click(object sender, EventArgs e)
        {
            Menu_Project1.Checked = false;
            Menu_Project2.Checked = false;
            Menu_Project3.Checked = false;
            Menu_Project4.Checked = false;
            Menu_Project5.Checked = !Menu_Project5.Checked;
            Menu_Project6.Checked = false;
            Menu_Project7.Checked = false;
            Menu_Project8.Checked = false;
        }

        private void Menu_Project6_Click(object sender, EventArgs e)
        {
            Menu_Project1.Checked = false;
            Menu_Project2.Checked = false;
            Menu_Project3.Checked = false;
            Menu_Project4.Checked = false;
            Menu_Project5.Checked = false;
            Menu_Project6.Checked = !Menu_Project6.Checked;
            Menu_Project7.Checked = false;
            Menu_Project8.Checked = false;
        }

        private void Menu_Project7_Click(object sender, EventArgs e)
        {
            Menu_Project1.Checked = false;
            Menu_Project2.Checked = false;
            Menu_Project3.Checked = false;
            Menu_Project4.Checked = false;
            Menu_Project5.Checked = false;
            Menu_Project6.Checked = false;
            Menu_Project7.Checked = !Menu_Project7.Checked;
            Menu_Project8.Checked = false;
        }

        private void Menu_Project8_Click(object sender, EventArgs e)
        {
            Menu_Project1.Checked = false;
            Menu_Project2.Checked = false;
            Menu_Project3.Checked = false;
            Menu_Project4.Checked = false;
            Menu_Project5.Checked = false;
            Menu_Project6.Checked = false;
            Menu_Project7.Checked = false;
            Menu_Project8.Checked = !Menu_Project8.Checked;
        }


        private void Menu_Inter_Poly_Click(object sender, EventArgs e)
        {
            Menu_DeCast.Checked = false;
            Menu_Bern.Checked = false;
            Menu_Midpoint.Checked = false;

            Menu_Inter_Poly.Checked = !Menu_Inter_Poly.Checked;
            Menu_Inter_Splines.Checked = false;

            Menu_DeBoor.Checked = false;

            Menu_Polyline.Enabled = false;
            Menu_Polyline.Checked = false;
            Menu_Points.Enabled = true;
            Menu_Shell.Enabled = false;
            Menu_Shell.Checked = false;

            ToggleDeBoorHUD(false);

            Refresh();
        }

        private void Menu_Inter_Splines_Click(object sender, EventArgs e)
        {
            Menu_DeCast.Checked = false;
            Menu_Bern.Checked = false;
            Menu_Midpoint.Checked = false;

            Menu_Inter_Poly.Checked = false;
            Menu_Inter_Splines.Checked = !Menu_Inter_Splines.Checked;

            Menu_DeBoor.Checked = false;

            Menu_Polyline.Enabled = false;
            Menu_Polyline.Checked = false;
            Menu_Points.Enabled = true;
            Menu_Shell.Enabled = false;
            Menu_Shell.Checked = false;

            ToggleDeBoorHUD(false);

            Refresh();
        }

        private void Menu_DeBoor_Click(object sender, EventArgs e)
        {
            Menu_DeCast.Checked = false;
            Menu_Bern.Checked = false;
            Menu_Midpoint.Checked = false;

            Menu_Inter_Poly.Checked = false;
            Menu_Inter_Splines.Checked = false;

            Menu_DeBoor.Checked = !Menu_DeBoor.Checked;

            Menu_Polyline.Enabled = true;
            Menu_Points.Enabled = true;
            Menu_Shell.Enabled = true;

            ToggleDeBoorHUD(true);

            Refresh();
        }

        private void DegreeClamp()
        {
            // handle edge cases
            degree_ = (degree_ > pts_.Count - 1) ? pts_.Count - 1 : degree_;
            degree_ = (degree_ < 1) ? 1 : degree_;
        }

        private void ResetKnotSeq( )
        {
            DegreeClamp();
            knot_.Clear();

            if (EdPtCont_)
            {
                for (int i = 0; i < degree_; ++i)
                    knot_.Add(0.0f);
                for (int i = 0; i <= (pts_.Count - degree_); ++i)
                    knot_.Add((float)i);
                for (int i = 0; i < degree_; ++i)
                    knot_.Add((float)(pts_.Count - degree_));
            }
            else
            {
                for (int i = -degree_; i <= (pts_.Count); ++i)
                    knot_.Add((float)i);
            }
        }

        private void UpdateKnotSeq()
        {
            Txt_knot.Clear();
            foreach (float knot in knot_)
            {
                Txt_knot.Text += knot.ToString() + " ";
            }
        }

        private void ToggleDeBoorHUD( bool on )
        {
            // set up basic knot sequence
            if( on )
            {
                ResetKnotSeq();
                UpdateKnotSeq();
            }

            CB_cont.Visible = on;

            Lbl_knot.Visible = on;
            Txt_knot.Visible = on;

            Lbl_degree.Visible = on;
            NUD_degree.Visible = on;
        }

        private void MAT290_Paint(object sender, PaintEventArgs e)
        {
            // pass the graphics object to the DrawScreen subroutine for processing
            DrawScreen(e.Graphics);
        }

        private void DrawScreen(System.Drawing.Graphics gfx)
        {


            PolynomialDegreeLabel.Visible = Menu_Project1.Checked;
            PolynomialDegreeValue.Visible = Menu_Project1.Checked;


            // to prevent unecessary drawing
            if (pts_.Count == 0)
                return;

            // pens used for drawing elements of the display
            System.Drawing.Pen polyPen = new Pen(Color.Gray, 1.0f);
            System.Drawing.Pen shellPen = new Pen(Color.Blue, 0.5f);
            System.Drawing.Pen splinePen = new Pen(Color.Red, 1.5f);

            if (Menu_Shell.Checked)
            {
                // draw the shell
                DrawShell(gfx, shellPen, pts_, tVal_);
            }

            if (Menu_Polyline.Checked)
            {
                // draw the control poly
                for (int i = 1; i < pts_.Count; ++i)
                {
                    gfx.DrawLine(polyPen, pts_[i - 1].P(), pts_[i].P());
                }
            }

            if (Menu_Points.Checked)
            {
                // draw the control points
                foreach (Point2D pt in pts_)
                {
                    gfx.DrawEllipse(polyPen, pt.x - 2.0F, pt.y - 2.0F, 4.0F, 4.0F);
                }
            }

            // you can change these variables at will; i have just chosen there
            //  to be six sample points for every point placed on the screen
            float steps = pts_.Count * 6;
            float alpha = 1 / steps;

            ///////////////////////////////////////////////////////////////////////////////
            // Drawing code for algorithms goes in here                                  //
            ///////////////////////////////////////////////////////////////////////////////

            //Project # checked
            if (Menu_Project1.Checked)
            {

                //Tweak these
                //Start with degree # of points
                //Initial degree:  1
                //Initial coef vals (have d+1 coef):  all 1's
                //Drag points up and down--coef corresponds to y val, do NOT change x val
                //Curve should move along with the coef. on its own given the stuff below
                //Up degree, change coef. / Bernstein poly all over again


                // DeCastlejau algorithm
                if (Menu_DeCast.Checked)
                {
                    Point2D current_left;
                    Point2D current_right = new Point2D(DeCastlejau(0));

                    for (float t = alpha; t < 1; t += alpha)
                    {
                        current_left = current_right;
                        current_right = DeCastlejau(t);
                        gfx.DrawLine(splinePen, current_left.P(), current_right.P());
                    }

                    gfx.DrawLine(splinePen, current_right.P(), DeCastlejau(1).P());
                }

                // Bernstein polynomial
                if (Menu_Bern.Checked)
                {
                    Point2D current_left;
                    Point2D current_right = new Point2D(Bernstein(0));

                    for (float t = alpha; t < 1; t += alpha)
                    {
                        current_left = current_right;
                        current_right = Bernstein(t);
                        gfx.DrawLine(splinePen, current_left.P(), current_right.P());
                    }

                    gfx.DrawLine(splinePen, current_right.P(), Bernstein(1).P());
                }






            }

            if (Menu_Project2.Checked)
            {

            }

            if (Menu_Project3.Checked)
            {

            }

            if (Menu_Project4.Checked)
            {

            }

            if (Menu_Project5.Checked)
            {

            }

            if (Menu_Project6.Checked)
            {

            }

            if (Menu_Project7.Checked)
            {

            }

            if (Menu_Project8.Checked)
            {

            }




            // DeCastlejau algorithm
            if (Menu_DeCast.Checked)
            {
                Point2D current_left;
                Point2D current_right = new Point2D(DeCastlejau(0));

                //Loop to connect 'major' points w/ coef. attached
                for (float t = alpha; t < 1; t += alpha)
                {
                    current_left = current_right;
                    current_right = DeCastlejau(t);
                    gfx.DrawLine(splinePen, current_left.P(), current_right.P());
                }

                gfx.DrawLine(splinePen, current_right.P(), DeCastlejau(1).P());
            }

            // Bernstein polynomial
            if (Menu_Bern.Checked)
            {
                Point2D current_left;
                Point2D current_right = new Point2D(Bernstein(0));




                for (float t = alpha; t < 1; t += alpha)
                {
                    current_left = current_right;


                 


                    current_right = Bernstein(t);

 


                    gfx.DrawLine(splinePen, current_left.P(), current_right.P());
                }


                //Do NOT want Bernstein(1), as this will make the (1-t) term always 0--cancels everything else out!
                //Instead, use something very close to 1
                gfx.DrawLine(splinePen, current_right.P(), Bernstein(1).P());
            }

            // Midpoint algorithm
            if (Menu_Midpoint.Checked)
            {
                DrawMidpoint(gfx, splinePen, pts_);
            }

            // polygon interpolation
            if (Menu_Inter_Poly.Checked)
            {
                Point2D current_left;
                Point2D current_right = new Point2D(PolyInterpolate(0));

                for (float t = alpha; t < 1; t += alpha)
                {
                    current_left = current_right;
                    current_right = PolyInterpolate(t);
                    gfx.DrawLine(splinePen, current_left.P(), current_right.P());
                }

                gfx.DrawLine(splinePen, current_right.P(), PolyInterpolate(1).P());
            }

            // spline interpolation
            if (Menu_Inter_Splines.Checked)
            {
                Point2D current_left;
                Point2D current_right = new Point2D(SplineInterpolate(0));

                for (float t = alpha; t < 1; t += alpha)
                {
                    current_left = current_right;
                    current_right = SplineInterpolate(t);
                    gfx.DrawLine(splinePen, current_left.P(), current_right.P());
                }

                gfx.DrawLine(splinePen, current_right.P(), SplineInterpolate(1).P());
            }

            // deboor
            if (Menu_DeBoor.Checked && pts_.Count >= 2)
            {
                Point2D current_left;
                Point2D current_right = new Point2D(DeBoorAlgthm(knot_[degree_]));

                float lastT = knot_[knot_.Count - degree_ - 1] - alpha;
                for (float t = alpha; t < lastT; t += alpha)
                {
                    current_left = current_right;
                    current_right = DeBoorAlgthm(t);
                    gfx.DrawLine(splinePen, current_left.P(), current_right.P());
                }

                gfx.DrawLine(splinePen, current_right.P(), DeBoorAlgthm(lastT).P());
            }

            ///////////////////////////////////////////////////////////////////////////////
            // Drawing code end                                                          //
            ///////////////////////////////////////////////////////////////////////////////


            // Heads up Display drawing code

            Font arial = new Font("Arial", 12);

            if (Menu_DeCast.Checked)
            {
                gfx.DrawString("DeCasteljau", arial, Brushes.Black, 0, 30);
            }
            else if (Menu_Midpoint.Checked)
            {
                gfx.DrawString("Midpoint", arial, Brushes.Black, 0, 30);
            }
            else if (Menu_Bern.Checked)
            {
                gfx.DrawString("Bernstein", arial, Brushes.Black, 0, 30);
            }
            else if (Menu_DeBoor.Checked)
            {
                gfx.DrawString("DeBoor", arial, Brushes.Black, 0, 30);
            }

            gfx.DrawString("t-value: " + tVal_.ToString("F"), arial, Brushes.Black, 500, 30);

            gfx.DrawString("t-step: " + alpha.ToString("F6"), arial, Brushes.Black, 600, 30);

            gfx.DrawString(pts_.Count.ToString(), arial, Brushes.Black, 750, 30);
        }

        private void DrawShell(System.Drawing.Graphics gfx, System.Drawing.Pen pen, List<Point2D> pts, float t)
        {

        }

        


        //USE pts_ FOR THESE ALGS -- COEF!
        private Point2D Gamma(int start, int end, float t)
        {
            return new Point2D(0, 0);
        }

        private Point2D DeCastlejau(float t)
        {
            if (pts_.Count == 1)
            {
                return pts_[0];
            }

            int pDTemp = pts_.Count;

            if (Menu_Project1.Checked)
            {
                pDTemp = polyDegree;
            }
          




            Point2D o = new Point2D(0, 0);

            if(updateP1DeCasteljauCoef)
            {
                int numCoef = pts_.Count;



                //Reset coef.
                for(int i=0;i<P1DecastlejauCoef.Count;i++)
                {
                    for(int j=0;j<P1DecastlejauCoef[i].Count;j++)
                    {
                        P1DecastlejauCoef[i][j] = new Point2D(INVALID_COEF, INVALID_COEF);
                    }
                }

                //Set starting coef
                for(int i=0;i<numCoef;++i)
                {
                    P1DecastlejauCoef[0][i] = pts_[i];
                }

                //Re-calculate position based on cumulative sum -- double check this part, might have a < vs. <= error
                for(int i=0;i<numCoef ;i++)
                {
                    for(int j=0;j<numCoef;j++)
                    {
                        P1DecastlejauCoef[i+1][j] = P1DecastlejauCoef[i][j] * (1 - t) + P1DecastlejauCoef[i][j +1] * t;


                        if(i==pDTemp && j==0)
                        {
                            i = numCoef;
                            j = numCoef;
                        }

                    }

                }

            }

            return P1DecastlejauCoef[pDTemp-1][0];
        }

        private Point2D Bernstein(float t)
        {

            //For d = # of coef (degree +1)
            // & Ai = coef. # i
            //  Bernstein poly sum p(t) =   sum from i = 0 -> d
            //  Ai * Bernstein poly(d, i, t)
            //  Bernstein poly(d, i, t) =   (d Choose i) * (1-t) ^ (d-i)     *    t ^ i


            // 
            /*
            if(pts_.Count==1)
            {
                return pts_[0];
            }
            */

            Point2D o = new Point2D(0, 0);

            int pDTemp = pts_.Count;

            if(Menu_Project1.Checked)
            {
                pDTemp = polyDegree;
            }

            for (int i=0;i<pDTemp;++i)
            {
               


                o += pts_[i] * BinomialCoef(pDTemp-1, i) * ((float)((Math.Pow((1 - t), pDTemp -1 - i) * Math.Pow(t, i))));
            }
            return o;

            //return new Point2D(0, 0);
            //return BernsteinCoef(1, t);
        }


        private Point2D BernsteinCoef(float c, float t)
        {
            return new Point2D(0, 0);
        }


        


        private const float MAX_DIST = 6.0F;
        private float INVALID_COEF = -999;

        private void DrawMidpoint(System.Drawing.Graphics gfx, System.Drawing.Pen pen, List<Point2D> cPs)
        {

        }

        private Point2D PolyInterpolate(float t)
        {
            return new Point2D(0, 0);
        }

        private Point2D SplineInterpolate(float t)
        {
            return new Point2D(0, 0);
        }

        private Point2D DeBoorAlgthm(float t)
        {
            return new Point2D(0, 0);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void PolyValueUpdated(object sender, EventArgs e)
        {
            polyDegree = (int)PolynomialDegreeValue.Value;
        }

    }
}