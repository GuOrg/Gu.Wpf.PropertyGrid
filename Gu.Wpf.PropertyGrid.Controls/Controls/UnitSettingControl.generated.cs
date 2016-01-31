namespace Gu.PropertyGrid
{
    using System.Windows;
    using Gu.Units;

    public class AccelerationSettingControl : UnitSettingControl<Acceleration, AccelerationUnit>
    {
        private static readonly AccelerationUnit DefaultUnit = AccelerationUnit.MetresPerSecondSquared;

        static AccelerationSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AccelerationSettingControl), new FrameworkPropertyMetadata(typeof(AccelerationSettingControl)));
            UnitProperty.OverrideMetadata(typeof(AccelerationSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(AccelerationSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class AmountOfSubstanceSettingControl : UnitSettingControl<AmountOfSubstance, AmountOfSubstanceUnit>
    {
        private static readonly AmountOfSubstanceUnit DefaultUnit = AmountOfSubstanceUnit.Moles;

        static AmountOfSubstanceSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AmountOfSubstanceSettingControl), new FrameworkPropertyMetadata(typeof(AmountOfSubstanceSettingControl)));
            UnitProperty.OverrideMetadata(typeof(AmountOfSubstanceSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(AmountOfSubstanceSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class AngleSettingControl : UnitSettingControl<Angle, AngleUnit>
    {
        private static readonly AngleUnit DefaultUnit = AngleUnit.Degrees;

        static AngleSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AngleSettingControl), new FrameworkPropertyMetadata(typeof(AngleSettingControl)));
            UnitProperty.OverrideMetadata(typeof(AngleSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(AngleSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class AnglePerUnitlessSettingControl : UnitSettingControl<AnglePerUnitless, AnglePerUnitlessUnit>
    {
        private static readonly AnglePerUnitlessUnit DefaultUnit = AnglePerUnitlessUnit.RadiansPerUnitless;

        static AnglePerUnitlessSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AnglePerUnitlessSettingControl), new FrameworkPropertyMetadata(typeof(AnglePerUnitlessSettingControl)));
            UnitProperty.OverrideMetadata(typeof(AnglePerUnitlessSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(AnglePerUnitlessSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class AngularAccelerationSettingControl : UnitSettingControl<AngularAcceleration, AngularAccelerationUnit>
    {
        private static readonly AngularAccelerationUnit DefaultUnit = AngularAccelerationUnit.RadiansPerSecondSquared;

        static AngularAccelerationSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AngularAccelerationSettingControl), new FrameworkPropertyMetadata(typeof(AngularAccelerationSettingControl)));
            UnitProperty.OverrideMetadata(typeof(AngularAccelerationSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(AngularAccelerationSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class AngularJerkSettingControl : UnitSettingControl<AngularJerk, AngularJerkUnit>
    {
        private static readonly AngularJerkUnit DefaultUnit = AngularJerkUnit.RadiansPerSecondCubed;

        static AngularJerkSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AngularJerkSettingControl), new FrameworkPropertyMetadata(typeof(AngularJerkSettingControl)));
            UnitProperty.OverrideMetadata(typeof(AngularJerkSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(AngularJerkSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class AngularSpeedSettingControl : UnitSettingControl<AngularSpeed, AngularSpeedUnit>
    {
        private static readonly AngularSpeedUnit DefaultUnit = AngularSpeedUnit.RadiansPerSecond;

        static AngularSpeedSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AngularSpeedSettingControl), new FrameworkPropertyMetadata(typeof(AngularSpeedSettingControl)));
            UnitProperty.OverrideMetadata(typeof(AngularSpeedSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(AngularSpeedSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class AreaSettingControl : UnitSettingControl<Area, AreaUnit>
    {
        private static readonly AreaUnit DefaultUnit = AreaUnit.SquareMetres;

        static AreaSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AreaSettingControl), new FrameworkPropertyMetadata(typeof(AreaSettingControl)));
            UnitProperty.OverrideMetadata(typeof(AreaSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(AreaSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class AreaDensitySettingControl : UnitSettingControl<AreaDensity, AreaDensityUnit>
    {
        private static readonly AreaDensityUnit DefaultUnit = AreaDensityUnit.KilogramsPerSquareMetre;

        static AreaDensitySettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AreaDensitySettingControl), new FrameworkPropertyMetadata(typeof(AreaDensitySettingControl)));
            UnitProperty.OverrideMetadata(typeof(AreaDensitySettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(AreaDensitySettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class CapacitanceSettingControl : UnitSettingControl<Capacitance, CapacitanceUnit>
    {
        private static readonly CapacitanceUnit DefaultUnit = CapacitanceUnit.Farads;

        static CapacitanceSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CapacitanceSettingControl), new FrameworkPropertyMetadata(typeof(CapacitanceSettingControl)));
            UnitProperty.OverrideMetadata(typeof(CapacitanceSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(CapacitanceSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class CatalyticActivitySettingControl : UnitSettingControl<CatalyticActivity, CatalyticActivityUnit>
    {
        private static readonly CatalyticActivityUnit DefaultUnit = CatalyticActivityUnit.Katals;

        static CatalyticActivitySettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CatalyticActivitySettingControl), new FrameworkPropertyMetadata(typeof(CatalyticActivitySettingControl)));
            UnitProperty.OverrideMetadata(typeof(CatalyticActivitySettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(CatalyticActivitySettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class CurrentSettingControl : UnitSettingControl<Current, CurrentUnit>
    {
        private static readonly CurrentUnit DefaultUnit = CurrentUnit.Amperes;

        static CurrentSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CurrentSettingControl), new FrameworkPropertyMetadata(typeof(CurrentSettingControl)));
            UnitProperty.OverrideMetadata(typeof(CurrentSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(CurrentSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class DataSettingControl : UnitSettingControl<Data, DataUnit>
    {
        private static readonly DataUnit DefaultUnit = DataUnit.Bits;

        static DataSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DataSettingControl), new FrameworkPropertyMetadata(typeof(DataSettingControl)));
            UnitProperty.OverrideMetadata(typeof(DataSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(DataSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class DensitySettingControl : UnitSettingControl<Density, DensityUnit>
    {
        private static readonly DensityUnit DefaultUnit = DensityUnit.KilogramsPerCubicMetre;

        static DensitySettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DensitySettingControl), new FrameworkPropertyMetadata(typeof(DensitySettingControl)));
            UnitProperty.OverrideMetadata(typeof(DensitySettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(DensitySettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class ElectricalConductanceSettingControl : UnitSettingControl<ElectricalConductance, ElectricalConductanceUnit>
    {
        private static readonly ElectricalConductanceUnit DefaultUnit = ElectricalConductanceUnit.Siemens;

        static ElectricalConductanceSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ElectricalConductanceSettingControl), new FrameworkPropertyMetadata(typeof(ElectricalConductanceSettingControl)));
            UnitProperty.OverrideMetadata(typeof(ElectricalConductanceSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(ElectricalConductanceSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class ElectricChargeSettingControl : UnitSettingControl<ElectricCharge, ElectricChargeUnit>
    {
        private static readonly ElectricChargeUnit DefaultUnit = ElectricChargeUnit.Coulombs;

        static ElectricChargeSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ElectricChargeSettingControl), new FrameworkPropertyMetadata(typeof(ElectricChargeSettingControl)));
            UnitProperty.OverrideMetadata(typeof(ElectricChargeSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(ElectricChargeSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class EnergySettingControl : UnitSettingControl<Energy, EnergyUnit>
    {
        private static readonly EnergyUnit DefaultUnit = EnergyUnit.Joules;

        static EnergySettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EnergySettingControl), new FrameworkPropertyMetadata(typeof(EnergySettingControl)));
            UnitProperty.OverrideMetadata(typeof(EnergySettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(EnergySettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class FlexibilitySettingControl : UnitSettingControl<Flexibility, FlexibilityUnit>
    {
        private static readonly FlexibilityUnit DefaultUnit = FlexibilityUnit.MetresPerNewton;

        static FlexibilitySettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlexibilitySettingControl), new FrameworkPropertyMetadata(typeof(FlexibilitySettingControl)));
            UnitProperty.OverrideMetadata(typeof(FlexibilitySettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(FlexibilitySettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class ForceSettingControl : UnitSettingControl<Force, ForceUnit>
    {
        private static readonly ForceUnit DefaultUnit = ForceUnit.Newtons;

        static ForceSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ForceSettingControl), new FrameworkPropertyMetadata(typeof(ForceSettingControl)));
            UnitProperty.OverrideMetadata(typeof(ForceSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(ForceSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class ForcePerUnitlessSettingControl : UnitSettingControl<ForcePerUnitless, ForcePerUnitlessUnit>
    {
        private static readonly ForcePerUnitlessUnit DefaultUnit = ForcePerUnitlessUnit.NewtonsPerUnitless;

        static ForcePerUnitlessSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ForcePerUnitlessSettingControl), new FrameworkPropertyMetadata(typeof(ForcePerUnitlessSettingControl)));
            UnitProperty.OverrideMetadata(typeof(ForcePerUnitlessSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(ForcePerUnitlessSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class FrequencySettingControl : UnitSettingControl<Frequency, FrequencyUnit>
    {
        private static readonly FrequencyUnit DefaultUnit = FrequencyUnit.Hertz;

        static FrequencySettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FrequencySettingControl), new FrameworkPropertyMetadata(typeof(FrequencySettingControl)));
            UnitProperty.OverrideMetadata(typeof(FrequencySettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(FrequencySettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class IlluminanceSettingControl : UnitSettingControl<Illuminance, IlluminanceUnit>
    {
        private static readonly IlluminanceUnit DefaultUnit = IlluminanceUnit.Lux;

        static IlluminanceSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IlluminanceSettingControl), new FrameworkPropertyMetadata(typeof(IlluminanceSettingControl)));
            UnitProperty.OverrideMetadata(typeof(IlluminanceSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(IlluminanceSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class InductanceSettingControl : UnitSettingControl<Inductance, InductanceUnit>
    {
        private static readonly InductanceUnit DefaultUnit = InductanceUnit.Henrys;

        static InductanceSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(InductanceSettingControl), new FrameworkPropertyMetadata(typeof(InductanceSettingControl)));
            UnitProperty.OverrideMetadata(typeof(InductanceSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(InductanceSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class JerkSettingControl : UnitSettingControl<Jerk, JerkUnit>
    {
        private static readonly JerkUnit DefaultUnit = JerkUnit.MetresPerSecondCubed;

        static JerkSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(JerkSettingControl), new FrameworkPropertyMetadata(typeof(JerkSettingControl)));
            UnitProperty.OverrideMetadata(typeof(JerkSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(JerkSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class KinematicViscositySettingControl : UnitSettingControl<KinematicViscosity, KinematicViscosityUnit>
    {
        private static readonly KinematicViscosityUnit DefaultUnit = KinematicViscosityUnit.SquareMetresPerSecond;

        static KinematicViscositySettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(KinematicViscositySettingControl), new FrameworkPropertyMetadata(typeof(KinematicViscositySettingControl)));
            UnitProperty.OverrideMetadata(typeof(KinematicViscositySettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(KinematicViscositySettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class LengthSettingControl : UnitSettingControl<Length, LengthUnit>
    {
        private static readonly LengthUnit DefaultUnit = LengthUnit.Millimetres;

        static LengthSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LengthSettingControl), new FrameworkPropertyMetadata(typeof(LengthSettingControl)));
            UnitProperty.OverrideMetadata(typeof(LengthSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(LengthSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class LengthPerUnitlessSettingControl : UnitSettingControl<LengthPerUnitless, LengthPerUnitlessUnit>
    {
        private static readonly LengthPerUnitlessUnit DefaultUnit = LengthPerUnitlessUnit.MetresPerUnitless;

        static LengthPerUnitlessSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LengthPerUnitlessSettingControl), new FrameworkPropertyMetadata(typeof(LengthPerUnitlessSettingControl)));
            UnitProperty.OverrideMetadata(typeof(LengthPerUnitlessSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(LengthPerUnitlessSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class LuminousFluxSettingControl : UnitSettingControl<LuminousFlux, LuminousFluxUnit>
    {
        private static readonly LuminousFluxUnit DefaultUnit = LuminousFluxUnit.Lumens;

        static LuminousFluxSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LuminousFluxSettingControl), new FrameworkPropertyMetadata(typeof(LuminousFluxSettingControl)));
            UnitProperty.OverrideMetadata(typeof(LuminousFluxSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(LuminousFluxSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class LuminousIntensitySettingControl : UnitSettingControl<LuminousIntensity, LuminousIntensityUnit>
    {
        private static readonly LuminousIntensityUnit DefaultUnit = LuminousIntensityUnit.Candelas;

        static LuminousIntensitySettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LuminousIntensitySettingControl), new FrameworkPropertyMetadata(typeof(LuminousIntensitySettingControl)));
            UnitProperty.OverrideMetadata(typeof(LuminousIntensitySettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(LuminousIntensitySettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class MagneticFieldStrengthSettingControl : UnitSettingControl<MagneticFieldStrength, MagneticFieldStrengthUnit>
    {
        private static readonly MagneticFieldStrengthUnit DefaultUnit = MagneticFieldStrengthUnit.Teslas;

        static MagneticFieldStrengthSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MagneticFieldStrengthSettingControl), new FrameworkPropertyMetadata(typeof(MagneticFieldStrengthSettingControl)));
            UnitProperty.OverrideMetadata(typeof(MagneticFieldStrengthSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(MagneticFieldStrengthSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class MagneticFluxSettingControl : UnitSettingControl<MagneticFlux, MagneticFluxUnit>
    {
        private static readonly MagneticFluxUnit DefaultUnit = MagneticFluxUnit.Webers;

        static MagneticFluxSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MagneticFluxSettingControl), new FrameworkPropertyMetadata(typeof(MagneticFluxSettingControl)));
            UnitProperty.OverrideMetadata(typeof(MagneticFluxSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(MagneticFluxSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class MassSettingControl : UnitSettingControl<Mass, MassUnit>
    {
        private static readonly MassUnit DefaultUnit = MassUnit.Kilograms;

        static MassSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MassSettingControl), new FrameworkPropertyMetadata(typeof(MassSettingControl)));
            UnitProperty.OverrideMetadata(typeof(MassSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(MassSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class MassFlowSettingControl : UnitSettingControl<MassFlow, MassFlowUnit>
    {
        private static readonly MassFlowUnit DefaultUnit = MassFlowUnit.KilogramsPerSecond;

        static MassFlowSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MassFlowSettingControl), new FrameworkPropertyMetadata(typeof(MassFlowSettingControl)));
            UnitProperty.OverrideMetadata(typeof(MassFlowSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(MassFlowSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class MomentumSettingControl : UnitSettingControl<Momentum, MomentumUnit>
    {
        private static readonly MomentumUnit DefaultUnit = MomentumUnit.NewtonSecond;

        static MomentumSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MomentumSettingControl), new FrameworkPropertyMetadata(typeof(MomentumSettingControl)));
            UnitProperty.OverrideMetadata(typeof(MomentumSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(MomentumSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class PowerSettingControl : UnitSettingControl<Power, PowerUnit>
    {
        private static readonly PowerUnit DefaultUnit = PowerUnit.Watts;

        static PowerSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PowerSettingControl), new FrameworkPropertyMetadata(typeof(PowerSettingControl)));
            UnitProperty.OverrideMetadata(typeof(PowerSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(PowerSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class PressureSettingControl : UnitSettingControl<Pressure, PressureUnit>
    {
        private static readonly PressureUnit DefaultUnit = PressureUnit.Megapascals;

        static PressureSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PressureSettingControl), new FrameworkPropertyMetadata(typeof(PressureSettingControl)));
            UnitProperty.OverrideMetadata(typeof(PressureSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(PressureSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class ResistanceSettingControl : UnitSettingControl<Resistance, ResistanceUnit>
    {
        private static readonly ResistanceUnit DefaultUnit = ResistanceUnit.Ohm;

        static ResistanceSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ResistanceSettingControl), new FrameworkPropertyMetadata(typeof(ResistanceSettingControl)));
            UnitProperty.OverrideMetadata(typeof(ResistanceSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(ResistanceSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class SolidAngleSettingControl : UnitSettingControl<SolidAngle, SolidAngleUnit>
    {
        private static readonly SolidAngleUnit DefaultUnit = SolidAngleUnit.Steradians;

        static SolidAngleSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SolidAngleSettingControl), new FrameworkPropertyMetadata(typeof(SolidAngleSettingControl)));
            UnitProperty.OverrideMetadata(typeof(SolidAngleSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(SolidAngleSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class SpecificEnergySettingControl : UnitSettingControl<SpecificEnergy, SpecificEnergyUnit>
    {
        private static readonly SpecificEnergyUnit DefaultUnit = SpecificEnergyUnit.JoulesPerKilogram;

        static SpecificEnergySettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SpecificEnergySettingControl), new FrameworkPropertyMetadata(typeof(SpecificEnergySettingControl)));
            UnitProperty.OverrideMetadata(typeof(SpecificEnergySettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(SpecificEnergySettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class SpecificVolumeSettingControl : UnitSettingControl<SpecificVolume, SpecificVolumeUnit>
    {
        private static readonly SpecificVolumeUnit DefaultUnit = SpecificVolumeUnit.CubicMetresPerKilogram;

        static SpecificVolumeSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SpecificVolumeSettingControl), new FrameworkPropertyMetadata(typeof(SpecificVolumeSettingControl)));
            UnitProperty.OverrideMetadata(typeof(SpecificVolumeSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(SpecificVolumeSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class SpeedSettingControl : UnitSettingControl<Speed, SpeedUnit>
    {
        private static readonly SpeedUnit DefaultUnit = SpeedUnit.MetresPerSecond;

        static SpeedSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SpeedSettingControl), new FrameworkPropertyMetadata(typeof(SpeedSettingControl)));
            UnitProperty.OverrideMetadata(typeof(SpeedSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(SpeedSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class StiffnessSettingControl : UnitSettingControl<Stiffness, StiffnessUnit>
    {
        private static readonly StiffnessUnit DefaultUnit = StiffnessUnit.NewtonsPerMetre;

        static StiffnessSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StiffnessSettingControl), new FrameworkPropertyMetadata(typeof(StiffnessSettingControl)));
            UnitProperty.OverrideMetadata(typeof(StiffnessSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(StiffnessSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class TemperatureSettingControl : UnitSettingControl<Temperature, TemperatureUnit>
    {
        private static readonly TemperatureUnit DefaultUnit = TemperatureUnit.Kelvin;

        static TemperatureSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TemperatureSettingControl), new FrameworkPropertyMetadata(typeof(TemperatureSettingControl)));
            UnitProperty.OverrideMetadata(typeof(TemperatureSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(TemperatureSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class TimeSettingControl : UnitSettingControl<Time, TimeUnit>
    {
        private static readonly TimeUnit DefaultUnit = TimeUnit.Seconds;

        static TimeSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimeSettingControl), new FrameworkPropertyMetadata(typeof(TimeSettingControl)));
            UnitProperty.OverrideMetadata(typeof(TimeSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(TimeSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class TorqueSettingControl : UnitSettingControl<Torque, TorqueUnit>
    {
        private static readonly TorqueUnit DefaultUnit = TorqueUnit.NewtonMetres;

        static TorqueSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TorqueSettingControl), new FrameworkPropertyMetadata(typeof(TorqueSettingControl)));
            UnitProperty.OverrideMetadata(typeof(TorqueSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(TorqueSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class UnitlessSettingControl : UnitSettingControl<Unitless, UnitlessUnit>
    {
        private static readonly UnitlessUnit DefaultUnit = UnitlessUnit.Scalar;

        static UnitlessSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UnitlessSettingControl), new FrameworkPropertyMetadata(typeof(UnitlessSettingControl)));
            UnitProperty.OverrideMetadata(typeof(UnitlessSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(UnitlessSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class VoltageSettingControl : UnitSettingControl<Voltage, VoltageUnit>
    {
        private static readonly VoltageUnit DefaultUnit = VoltageUnit.Volts;

        static VoltageSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VoltageSettingControl), new FrameworkPropertyMetadata(typeof(VoltageSettingControl)));
            UnitProperty.OverrideMetadata(typeof(VoltageSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(VoltageSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class VolumeSettingControl : UnitSettingControl<Volume, VolumeUnit>
    {
        private static readonly VolumeUnit DefaultUnit = VolumeUnit.CubicMetres;

        static VolumeSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VolumeSettingControl), new FrameworkPropertyMetadata(typeof(VolumeSettingControl)));
            UnitProperty.OverrideMetadata(typeof(VolumeSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(VolumeSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class VolumetricFlowSettingControl : UnitSettingControl<VolumetricFlow, VolumetricFlowUnit>
    {
        private static readonly VolumetricFlowUnit DefaultUnit = VolumetricFlowUnit.CubicMetresPerSecond;

        static VolumetricFlowSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VolumetricFlowSettingControl), new FrameworkPropertyMetadata(typeof(VolumetricFlowSettingControl)));
            UnitProperty.OverrideMetadata(typeof(VolumetricFlowSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(VolumetricFlowSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }

    public class WavenumberSettingControl : UnitSettingControl<Wavenumber, WavenumberUnit>
    {
        private static readonly WavenumberUnit DefaultUnit = WavenumberUnit.ReciprocalMetres;

        static WavenumberSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WavenumberSettingControl), new FrameworkPropertyMetadata(typeof(WavenumberSettingControl)));
            UnitProperty.OverrideMetadata(typeof(WavenumberSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(typeof(WavenumberSettingControl), new PropertyMetadata(DefaultUnit.Symbol));
        }
    }
}

