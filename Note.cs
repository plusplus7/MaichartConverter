﻿using System.Numerics;

namespace MaichartConverter
{
    /// <summary>
    /// Basic note
    /// </summary>
    public abstract class Note : IEquatable<Note>, INote, IComparable
    {
        /// <summary>
        /// The note type
        /// </summary>
        private string noteType;

        /// <summary>
        /// The key
        /// </summary>
        private string key;

        /// <summary>
        /// The end key
        /// </summary>
        private string endKey;

        /// <summary>
        /// The bar
        /// </summary>
        private int bar;

        /// <summary>
        /// The start time
        /// </summary>
        private int tick;

        /// <summary>
        /// The absolute tick calculated by this.bar*384+this.tick
        /// </summary>
        private int tickStamp;

        /// <summary>
        /// The start time stamp
        /// </summary>
        private double tickTimeStamp;

        /// <summary>
        /// The wait time
        /// </summary>
        private int waitTime;

        /// <summary>
        /// The stamp of wait time ends in ticks
        /// </summary>
        private int waitStamp;

        /// <summary>
        /// The stamp when the wait time ends in seconds
        /// </summary>
        private double waitTimeStamp;

        /// <summary>
        /// The calculated wait time in seconds
        /// </summary>
        private double calculatedWaitTime;

        /// <summary>
        /// The last time
        /// </summary>
        private int lastTime;

        /// <summary>
        /// The stamp when the last time ends in ticks
        /// </summary>
        private int lastStamp;

        /// <summary>
        /// The stamp when the last time ends in seconds
        /// </summary>
        private double lastTimeStamp;

        /// <summary>
        /// The calculated last time
        /// </summary>
        private double calculatedLastTime;

        /// <summary>
        /// The delayed
        /// </summary>
        private bool delayed;

        /// <summary>
        /// The BPM
        /// </summary>
        private double bpm;

        /// <summary>
        /// The previous
        /// </summary>
        private Note? prev;

        /// <summary>
        /// The next
        /// </summary>
        private Note? next;

        /// <summary>
        /// Stores the start note of slide
        /// </summary>
        private Note? slideStart;

        /// <summary>
        /// Stores the connecting slide of slide start
        /// </summary>
        private Note? consecutiveSlide;

        /// <summary>
        /// The next BPM change to this note
        /// </summary>
        private BPMChange? nextBPMChange;

        /// <summary>
        /// Construct an empty note
        /// </summary>
        public Note()
        {
            noteType = "";
            key = "";
            endKey = "";
            bar = 0;
            tick = 0;
            tickStamp = 0;
            tickTimeStamp = 0.0;
            lastTime = 0;
            lastStamp = 0;
            lastTimeStamp = 0.0;
            waitTime = 0;
            waitStamp = 0;
            waitTimeStamp = 0.0;
            calculatedLastTime = 0.0;
            calculatedWaitTime = 0.0;
            bpm = 0;
        }

        /// <summary>
        /// Construct a note from other note
        /// </summary>
        /// <param name="inTake">The intake note</param>
        public Note(Note inTake)
        {
            this.noteType = inTake.NoteType;
            this.key = inTake.Key;
            this.endKey = inTake.EndKey;
            this.bar = inTake.Bar;
            this.tick = inTake.Tick;
            this.tickStamp = inTake.TickStamp;
            this.tickTimeStamp = inTake.TickTimeStamp;
            this.lastTime = inTake.LastTime;
            this.lastStamp = inTake.LastStamp;
            this.lastTimeStamp = inTake.LastTimeStamp;
            this.waitTime = inTake.WaitTime;
            this.waitStamp = inTake.WaitStamp;
            this.waitTimeStamp = inTake.WaitTimeStamp;
            this.calculatedLastTime = inTake.CalculatedLastTime;
            this.calculatedLastTime = inTake.CalculatedLastTime;
            this.bpm = inTake.bpm;
        }

        /// <summary>
        /// Access NoteType
        /// </summary>
        public string NoteType
        {
            get
            {
                return this.noteType;
            }
            set
            {
                this.noteType = value;
            }
        }

        /// <summary>
        /// Access Key
        /// </summary>
        public string Key
        {
            get
            {
                return this.key;
            }
            set
            {
                this.key = value;
            }
        }

        /// <summary>
        /// Access Bar
        /// </summary>
        public int Bar
        {
            get
            {
                return this.bar;
            }
            set
            {
                this.bar = value;
            }
        }

        /// <summary>
        /// Access Tick
        /// </summary>
        public int Tick
        {
            get
            {
                return this.tick;
            }
            set
            {
                this.tick = value;
            }
        }

        /// <summary>
        /// Access Tick Stamp = this.Bar*384 + this.Tick
        /// </summary>
        public int TickStamp
        {
            get { return this.tickStamp; }
            set { this.tickStamp = value; }
        }

        /// <summary>
        /// Access Tick Stamp = this.Bar*384 + this.Tick
        /// </summary>
        public double TickTimeStamp
        {
            get { return this.tickTimeStamp; }
            set { this.tickTimeStamp = value; }
        }

        /// <summary>
        /// Access wait time
        /// </summary>
        public int WaitTime
        {
            get
            {
                return this.waitTime;
            }
            set
            {
                this.waitTime = value;
            }
        }

        /// <summary>
        /// Access the time stamp where wait time ends in ticks
        /// </summary>
        /// <value>The incoming time</value>
        public int WaitStamp
        {
            get { return this.waitStamp; }
            set { this.waitStamp = value; }
        }

        /// <summary>
        /// Access the time stamp where wait time ends in seconds
        /// </summary>
        /// <value>The incoming time</value>
        public double WaitTimeStamp
        {
            get { return this.waitTimeStamp; }
            set { this.waitTimeStamp = value; }
        }

        /// <summary>
        /// Gets or sets the calculated wait time.
        /// </summary>
        /// <value>
        /// The calculated wait time in seconds.
        /// </value>
        public double CalculatedWaitTime
        {
            get { return this.calculatedWaitTime; }
            set { this.calculatedWaitTime = value; }
        }

        /// <summary>
        /// Access EndTime
        /// </summary>
        public int LastTime
        {
            get
            {
                return this.lastTime;
            }
            set
            {
                this.lastTime = value;
            }
        }

        /// <summary>
        /// Access Last time in ticks
        /// </summary>
        public int LastStamp
        {
            get
            {
                return this.lastStamp;
            }
            set
            {
                this.lastStamp = value;
            }
        }

        /// <summary>
        /// Access last time in seconds
        /// </summary>
        public double LastTimeStamp
        {
            get
            {
                return this.lastTimeStamp;
            }
            set
            {
                this.lastTimeStamp = value;
            }
        }

        /// <summary>
        /// Gets or sets the calculated last time in seconds.
        /// </summary>
        /// <value>
        /// The calculated last time in seconds.
        /// </value>
        public double CalculatedLastTime
        {
            get => this.calculatedLastTime;
            set { this.calculatedLastTime = value; }
        }

        /// <summary>
        /// Access EndKey
        /// </summary>
        public string EndKey
        {
            get
            {
                return this.endKey;
            }
            set
            {
                this.endKey = value;
            }
        }

        /// <summary>
        /// Access Delayed
        /// </summary>
        public bool Delayed
        {
            get { return this.delayed; }
            set { this.delayed = value; }
        }

        /// <summary>
        /// Access BPM
        /// </summary>
        public double BPM
        {
            get { return this.bpm; }
            set { this.bpm = value; }
        }

        /// <summary>
        /// Access this.prev;
        /// </summary>
        public Note? Prev
        {
            get { return this.prev; }
            set { this.prev = value; }
        }

        /// <summary>
        /// Access this.next
        /// </summary>
        public Note? Next
        {
            get { return this.next; }
            set { this.next = value; }
        }

        /// <summary>
        /// Return the slide start of a note (reserved for slides only)
        /// </summary>
        public Note? SlideStart
        {
            get { return this.slideStart; }
            set { this.slideStart = value; }
        }

        /// <summary>
        /// Return the consecutive of a note (reserved for slides only)
        /// </summary>
        public Note? ConsecutiveSlide
        {
            get { return this.consecutiveSlide; }
            set { this.consecutiveSlide = value; }
        }

        /// <summary>
        /// Return this.SpecificType
        /// </summary>
        /// <returns>string of specific genre (specific type of Tap, Slide, etc.)</returns>
        public abstract string NoteSpecificType { get; }

        /// <summary>
        /// Return this.noteGenre
        /// </summary>
        /// <returns>string of note genre (general category of TAP, SLIDE and HOLD)</returns>
        public abstract string NoteGenre { get; }

        /// <summary>
        /// Return if this is a true note
        /// </summary>
        /// <returns>True if is TAP,HOLD or SLIDE, false elsewise</returns>
        public abstract bool IsNote { get; }

        public abstract bool CheckValidity();

        public abstract string Compose(int format);

        public int CompareTo(Object? obj)
        {
            int result = 0;

            Note another = obj as Note ?? throw new NullReferenceException("Note is not defined");

            //else if (this.NoteSpecificType().Equals("SLIDE")&&(this.NoteSpecificType().Equals("TAP")|| this.NoteSpecificType().Equals("HOLD")) && this.tick == another.Tick && this.bar == another.Bar)
            //{
            //    result = -1;
            //}
            //else if (this.NoteSpecificType().Equals("SLIDE_START") && (another.NoteSpecificType().Equals("TAP") || another.NoteSpecificType().Equals("HOLD")) && this.tick == another.Tick && this.bar == another.Bar)
            //{
            //    Console.WriteLine("STAR AND TAP");
            //    result = 1;
            //    Console.WriteLine(this.NoteSpecificType() + ".compareTo(" + another.NoteSpecificType() + ") is" + result);
            //    //Console.ReadKey();
            //}
            //if (this.Bar==another.Bar&&this.Tick==another.Tick)
            //{
            //    if (this.NoteGenre().Equals("BPM"))
            //    {
            //        result = -1;
            //    }
            //    else if (this.NoteGenre().Equals("MEASURE"))
            //    {
            //        result = 1;
            //    }
            //    else if ((this.NoteSpecificType().Equals("TAP")|| this.NoteSpecificType().Equals("HOLD"))&&another.NoteSpecificType().Equals("SLIDE_START"))
            //    {
            //        result= -1;
            //    }
            //}
            //else
            //{
            //    if (this.bar != another.Bar)
            //    {
            //        result = this.bar.CompareTo(another.Bar);
            //        //Console.WriteLine("this.compareTo(another) is" + result);
            //        //Console.ReadKey();
            //    }
            //    else result = this.tick.CompareTo(another.Tick);
            //}
            if (this.Bar != another.Bar)
            {
                result = this.Bar.CompareTo(another.Bar);
            }
            else if (this.Bar == another.Bar && (this.Tick != another.Tick))
            {
                result = this.Tick.CompareTo(another.Tick);
            }
            else
            {
                if (this.NoteSpecificType.Equals("BPM"))
                {
                    result = -1;
                }
                //else if (this.NoteSpecificType().Equals("SLIDE")&&another.NoteSpecificType().Equals("SLIDE_START")&&this.Key.Equals(another.Key))
                //{
                //    result = 1;
                //}
                else result = 0;
            }
            return result;
        }

        public bool Equals(Note? other)
        {
            bool result = false;
            if (other != null &&
            this.NoteType.Equals(other.NoteType) &&
            this.Key.Equals(other.Key) &&
            this.EndKey.Equals(other.EndKey) &&
            this.Bar == other.Bar &&
            this.Tick == other.Tick &&
            this.LastTime == other.LastTime &&
            this.BPM == other.BPM)
            {
                result = true;
            }
            return result;
        }

        public bool Update()
        {
            bool result = false;
            this.tickStamp = this.Bar * 384 + this.tick;
            this.waitStamp = this.TickStamp + this.waitTime;
            this.lastStamp = this.waitStamp + this.lastStamp;
            if (!(this.NoteType.Equals("SLIDE") || this.NoteType.Equals("HOLD")))
            {
                result = true;
            }
            else if (this.calculatedLastTime > 0 && this.calculatedWaitTime > 0)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Generate appropriate length for hold and slide.
        /// </summary>
        /// <param name="length">Last Time</param>
        /// <returns>[Definition:Length]=[Quaver:Beat]</returns>
        public string GenerateAppropriateLength(int length)
        {
            string result = "";
            const int definition = 384;
            int divisor = GCD(definition, length);
            int quaver = definition / divisor, beat = length / divisor;
            result = "[" + quaver.ToString() + ":" + beat.ToString() + "]";
            return result;
        }

        /// <summary>
        /// Return GCD of A and B.
        /// </summary>
        /// <param name="a">A</param>
        /// <param name="b">B</param>
        /// <returns>GCD of A and B</returns>
        static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        /// <summary>
        /// Generate appropriate length for hold and slide.
        /// </summary>
        /// <param name="length">Last Time</param>
        /// <param name="bpm">BPM</param>
        /// <returns>[Definition:Length]=[Quaver:Beat]</returns>
        public string GenerateAppropriateLength(int length, double bpm)
        {
            string result = "";
            double tickTime = 60 / bpm * 4 / 384;
            double sustain = this.WaitTime * tickTime;
            double duration = this.LastTime * tickTime;
            result = "[" + sustain + "##" + duration + "]";
            return result;
        }
    }
}
