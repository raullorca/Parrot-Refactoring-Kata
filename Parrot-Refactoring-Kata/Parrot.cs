using System;

namespace parrot
{
    public abstract class Parrot
    {
        protected const double MIN_SPEED = 0;
        protected const double BASE_SPEED = 12.0;

        public static Parrot Create(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed)
        {
            if (isNailed)
                return new NailedParrot();

            if (type == ParrotTypeEnum.EUROPEAN)
            {
                return new EuropeanParrot();
            }
            if (type == ParrotTypeEnum.AFRICAN)
            {
                return new AfricanParrot(numberOfCoconuts);
            }
            return new NorwegianBlueParrot(voltage);
        }

        public abstract double GetSpeed();
    }

    internal class EuropeanParrot : Parrot
    {
        public override double GetSpeed()
        {
            return BASE_SPEED;
        }
    }

    internal class AfricanParrot : Parrot
    {
        private const double LOAD_FACTOR = 9.0;
        
        private int _numberOfCoconuts;
        public AfricanParrot(int numberOfCoconuts)
        {
            _numberOfCoconuts = numberOfCoconuts;
        }

        public override double GetSpeed()
        {
            return Math.Max(MIN_SPEED, BASE_SPEED - LOAD_FACTOR * _numberOfCoconuts);
        }
    }

    internal class NorwegianBlueParrot : Parrot
    {
        private const double MAX_SPEED = 24.0;

        private double _voltage;

        public NorwegianBlueParrot(double voltage)
        {
            _voltage = voltage;
        }

        public override double GetSpeed()
        {
            return Math.Min(MAX_SPEED, _voltage * BASE_SPEED);
        }
    }

    internal class NailedParrot : Parrot
    {
        public override double GetSpeed()
        {
            return MIN_SPEED;
        }
    }
}
