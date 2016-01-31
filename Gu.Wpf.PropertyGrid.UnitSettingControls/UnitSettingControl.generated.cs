namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using Gu.Units;

    public class AccelerationSettingControl : UnitSettingControl<Acceleration, AccelerationUnit>
    {
        public static readonly AccelerationUnit DefaultUnit = AccelerationUnit.MetresPerSecondSquared;

        static AccelerationSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AccelerationSettingControl), new FrameworkPropertyMetadata(typeof(AccelerationSettingControl)));
            UnitProperty.OverrideMetadata(typeof(AccelerationSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(AccelerationSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class AmountOfSubstanceSettingControl : UnitSettingControl<AmountOfSubstance, AmountOfSubstanceUnit>
    {
        public static readonly AmountOfSubstanceUnit DefaultUnit = AmountOfSubstanceUnit.Moles;

        static AmountOfSubstanceSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AmountOfSubstanceSettingControl), new FrameworkPropertyMetadata(typeof(AmountOfSubstanceSettingControl)));
            UnitProperty.OverrideMetadata(typeof(AmountOfSubstanceSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(AmountOfSubstanceSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class AngleSettingControl : UnitSettingControl<Angle, AngleUnit>
    {
        public static readonly AngleUnit DefaultUnit = AngleUnit.Degrees;

        static AngleSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AngleSettingControl), new FrameworkPropertyMetadata(typeof(AngleSettingControl)));
            UnitProperty.OverrideMetadata(typeof(AngleSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(AngleSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class AnglePerUnitlessSettingControl : UnitSettingControl<AnglePerUnitless, AnglePerUnitlessUnit>
    {
        public static readonly AnglePerUnitlessUnit DefaultUnit = AnglePerUnitlessUnit.RadiansPerUnitless;

        static AnglePerUnitlessSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AnglePerUnitlessSettingControl), new FrameworkPropertyMetadata(typeof(AnglePerUnitlessSettingControl)));
            UnitProperty.OverrideMetadata(typeof(AnglePerUnitlessSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(AnglePerUnitlessSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class AngularAccelerationSettingControl : UnitSettingControl<AngularAcceleration, AngularAccelerationUnit>
    {
        public static readonly AngularAccelerationUnit DefaultUnit = AngularAccelerationUnit.RadiansPerSecondSquared;

        static AngularAccelerationSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AngularAccelerationSettingControl), new FrameworkPropertyMetadata(typeof(AngularAccelerationSettingControl)));
            UnitProperty.OverrideMetadata(typeof(AngularAccelerationSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(AngularAccelerationSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class AngularJerkSettingControl : UnitSettingControl<AngularJerk, AngularJerkUnit>
    {
        public static readonly AngularJerkUnit DefaultUnit = AngularJerkUnit.RadiansPerSecondCubed;

        static AngularJerkSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AngularJerkSettingControl), new FrameworkPropertyMetadata(typeof(AngularJerkSettingControl)));
            UnitProperty.OverrideMetadata(typeof(AngularJerkSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(AngularJerkSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class AngularSpeedSettingControl : UnitSettingControl<AngularSpeed, AngularSpeedUnit>
    {
        public static readonly AngularSpeedUnit DefaultUnit = AngularSpeedUnit.RadiansPerSecond;

        static AngularSpeedSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AngularSpeedSettingControl), new FrameworkPropertyMetadata(typeof(AngularSpeedSettingControl)));
            UnitProperty.OverrideMetadata(typeof(AngularSpeedSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(AngularSpeedSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class AreaSettingControl : UnitSettingControl<Area, AreaUnit>
    {
        public static readonly AreaUnit DefaultUnit = AreaUnit.SquareMetres;

        static AreaSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AreaSettingControl), new FrameworkPropertyMetadata(typeof(AreaSettingControl)));
            UnitProperty.OverrideMetadata(typeof(AreaSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(AreaSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class AreaDensitySettingControl : UnitSettingControl<AreaDensity, AreaDensityUnit>
    {
        public static readonly AreaDensityUnit DefaultUnit = AreaDensityUnit.KilogramsPerSquareMetre;

        static AreaDensitySettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AreaDensitySettingControl), new FrameworkPropertyMetadata(typeof(AreaDensitySettingControl)));
            UnitProperty.OverrideMetadata(typeof(AreaDensitySettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(AreaDensitySettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class CapacitanceSettingControl : UnitSettingControl<Capacitance, CapacitanceUnit>
    {
        public static readonly CapacitanceUnit DefaultUnit = CapacitanceUnit.Farads;

        static CapacitanceSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CapacitanceSettingControl), new FrameworkPropertyMetadata(typeof(CapacitanceSettingControl)));
            UnitProperty.OverrideMetadata(typeof(CapacitanceSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(CapacitanceSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class CatalyticActivitySettingControl : UnitSettingControl<CatalyticActivity, CatalyticActivityUnit>
    {
        public static readonly CatalyticActivityUnit DefaultUnit = CatalyticActivityUnit.Katals;

        static CatalyticActivitySettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CatalyticActivitySettingControl), new FrameworkPropertyMetadata(typeof(CatalyticActivitySettingControl)));
            UnitProperty.OverrideMetadata(typeof(CatalyticActivitySettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(CatalyticActivitySettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class CurrentSettingControl : UnitSettingControl<Current, CurrentUnit>
    {
        public static readonly CurrentUnit DefaultUnit = CurrentUnit.Amperes;

        static CurrentSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CurrentSettingControl), new FrameworkPropertyMetadata(typeof(CurrentSettingControl)));
            UnitProperty.OverrideMetadata(typeof(CurrentSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(CurrentSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class DataSettingControl : UnitSettingControl<Data, DataUnit>
    {
        public static readonly DataUnit DefaultUnit = DataUnit.Bits;

        static DataSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DataSettingControl), new FrameworkPropertyMetadata(typeof(DataSettingControl)));
            UnitProperty.OverrideMetadata(typeof(DataSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(DataSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class DensitySettingControl : UnitSettingControl<Density, DensityUnit>
    {
        public static readonly DensityUnit DefaultUnit = DensityUnit.KilogramsPerCubicMetre;

        static DensitySettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DensitySettingControl), new FrameworkPropertyMetadata(typeof(DensitySettingControl)));
            UnitProperty.OverrideMetadata(typeof(DensitySettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(DensitySettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class ElectricalConductanceSettingControl : UnitSettingControl<ElectricalConductance, ElectricalConductanceUnit>
    {
        public static readonly ElectricalConductanceUnit DefaultUnit = ElectricalConductanceUnit.Siemens;

        static ElectricalConductanceSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ElectricalConductanceSettingControl), new FrameworkPropertyMetadata(typeof(ElectricalConductanceSettingControl)));
            UnitProperty.OverrideMetadata(typeof(ElectricalConductanceSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(ElectricalConductanceSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class ElectricChargeSettingControl : UnitSettingControl<ElectricCharge, ElectricChargeUnit>
    {
        public static readonly ElectricChargeUnit DefaultUnit = ElectricChargeUnit.Coulombs;

        static ElectricChargeSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ElectricChargeSettingControl), new FrameworkPropertyMetadata(typeof(ElectricChargeSettingControl)));
            UnitProperty.OverrideMetadata(typeof(ElectricChargeSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(ElectricChargeSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class EnergySettingControl : UnitSettingControl<Energy, EnergyUnit>
    {
        public static readonly EnergyUnit DefaultUnit = EnergyUnit.Joules;

        static EnergySettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EnergySettingControl), new FrameworkPropertyMetadata(typeof(EnergySettingControl)));
            UnitProperty.OverrideMetadata(typeof(EnergySettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(EnergySettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class FlexibilitySettingControl : UnitSettingControl<Flexibility, FlexibilityUnit>
    {
        public static readonly FlexibilityUnit DefaultUnit = FlexibilityUnit.MetresPerNewton;

        static FlexibilitySettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlexibilitySettingControl), new FrameworkPropertyMetadata(typeof(FlexibilitySettingControl)));
            UnitProperty.OverrideMetadata(typeof(FlexibilitySettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(FlexibilitySettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class ForceSettingControl : UnitSettingControl<Force, ForceUnit>
    {
        public static readonly ForceUnit DefaultUnit = ForceUnit.Newtons;

        static ForceSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ForceSettingControl), new FrameworkPropertyMetadata(typeof(ForceSettingControl)));
            UnitProperty.OverrideMetadata(typeof(ForceSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(ForceSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class ForcePerUnitlessSettingControl : UnitSettingControl<ForcePerUnitless, ForcePerUnitlessUnit>
    {
        public static readonly ForcePerUnitlessUnit DefaultUnit = ForcePerUnitlessUnit.NewtonsPerUnitless;

        static ForcePerUnitlessSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ForcePerUnitlessSettingControl), new FrameworkPropertyMetadata(typeof(ForcePerUnitlessSettingControl)));
            UnitProperty.OverrideMetadata(typeof(ForcePerUnitlessSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(ForcePerUnitlessSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class FrequencySettingControl : UnitSettingControl<Frequency, FrequencyUnit>
    {
        public static readonly FrequencyUnit DefaultUnit = FrequencyUnit.Hertz;

        static FrequencySettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FrequencySettingControl), new FrameworkPropertyMetadata(typeof(FrequencySettingControl)));
            UnitProperty.OverrideMetadata(typeof(FrequencySettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(FrequencySettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class IlluminanceSettingControl : UnitSettingControl<Illuminance, IlluminanceUnit>
    {
        public static readonly IlluminanceUnit DefaultUnit = IlluminanceUnit.Lux;

        static IlluminanceSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IlluminanceSettingControl), new FrameworkPropertyMetadata(typeof(IlluminanceSettingControl)));
            UnitProperty.OverrideMetadata(typeof(IlluminanceSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(IlluminanceSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class InductanceSettingControl : UnitSettingControl<Inductance, InductanceUnit>
    {
        public static readonly InductanceUnit DefaultUnit = InductanceUnit.Henrys;

        static InductanceSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(InductanceSettingControl), new FrameworkPropertyMetadata(typeof(InductanceSettingControl)));
            UnitProperty.OverrideMetadata(typeof(InductanceSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(InductanceSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class JerkSettingControl : UnitSettingControl<Jerk, JerkUnit>
    {
        public static readonly JerkUnit DefaultUnit = JerkUnit.MetresPerSecondCubed;

        static JerkSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(JerkSettingControl), new FrameworkPropertyMetadata(typeof(JerkSettingControl)));
            UnitProperty.OverrideMetadata(typeof(JerkSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(JerkSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class KinematicViscositySettingControl : UnitSettingControl<KinematicViscosity, KinematicViscosityUnit>
    {
        public static readonly KinematicViscosityUnit DefaultUnit = KinematicViscosityUnit.SquareMetresPerSecond;

        static KinematicViscositySettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(KinematicViscositySettingControl), new FrameworkPropertyMetadata(typeof(KinematicViscositySettingControl)));
            UnitProperty.OverrideMetadata(typeof(KinematicViscositySettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(KinematicViscositySettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class LengthSettingControl : UnitSettingControl<Length, LengthUnit>
    {
        public static readonly LengthUnit DefaultUnit = LengthUnit.Millimetres;

        static LengthSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LengthSettingControl), new FrameworkPropertyMetadata(typeof(LengthSettingControl)));
            UnitProperty.OverrideMetadata(typeof(LengthSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(LengthSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class LengthPerUnitlessSettingControl : UnitSettingControl<LengthPerUnitless, LengthPerUnitlessUnit>
    {
        public static readonly LengthPerUnitlessUnit DefaultUnit = LengthPerUnitlessUnit.MetresPerUnitless;

        static LengthPerUnitlessSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LengthPerUnitlessSettingControl), new FrameworkPropertyMetadata(typeof(LengthPerUnitlessSettingControl)));
            UnitProperty.OverrideMetadata(typeof(LengthPerUnitlessSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(LengthPerUnitlessSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class LuminousFluxSettingControl : UnitSettingControl<LuminousFlux, LuminousFluxUnit>
    {
        public static readonly LuminousFluxUnit DefaultUnit = LuminousFluxUnit.Lumens;

        static LuminousFluxSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LuminousFluxSettingControl), new FrameworkPropertyMetadata(typeof(LuminousFluxSettingControl)));
            UnitProperty.OverrideMetadata(typeof(LuminousFluxSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(LuminousFluxSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class LuminousIntensitySettingControl : UnitSettingControl<LuminousIntensity, LuminousIntensityUnit>
    {
        public static readonly LuminousIntensityUnit DefaultUnit = LuminousIntensityUnit.Candelas;

        static LuminousIntensitySettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LuminousIntensitySettingControl), new FrameworkPropertyMetadata(typeof(LuminousIntensitySettingControl)));
            UnitProperty.OverrideMetadata(typeof(LuminousIntensitySettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(LuminousIntensitySettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class MagneticFieldStrengthSettingControl : UnitSettingControl<MagneticFieldStrength, MagneticFieldStrengthUnit>
    {
        public static readonly MagneticFieldStrengthUnit DefaultUnit = MagneticFieldStrengthUnit.Teslas;

        static MagneticFieldStrengthSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MagneticFieldStrengthSettingControl), new FrameworkPropertyMetadata(typeof(MagneticFieldStrengthSettingControl)));
            UnitProperty.OverrideMetadata(typeof(MagneticFieldStrengthSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(MagneticFieldStrengthSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class MagneticFluxSettingControl : UnitSettingControl<MagneticFlux, MagneticFluxUnit>
    {
        public static readonly MagneticFluxUnit DefaultUnit = MagneticFluxUnit.Webers;

        static MagneticFluxSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MagneticFluxSettingControl), new FrameworkPropertyMetadata(typeof(MagneticFluxSettingControl)));
            UnitProperty.OverrideMetadata(typeof(MagneticFluxSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(MagneticFluxSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class MassSettingControl : UnitSettingControl<Mass, MassUnit>
    {
        public static readonly MassUnit DefaultUnit = MassUnit.Kilograms;

        static MassSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MassSettingControl), new FrameworkPropertyMetadata(typeof(MassSettingControl)));
            UnitProperty.OverrideMetadata(typeof(MassSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(MassSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class MassFlowSettingControl : UnitSettingControl<MassFlow, MassFlowUnit>
    {
        public static readonly MassFlowUnit DefaultUnit = MassFlowUnit.KilogramsPerSecond;

        static MassFlowSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MassFlowSettingControl), new FrameworkPropertyMetadata(typeof(MassFlowSettingControl)));
            UnitProperty.OverrideMetadata(typeof(MassFlowSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(MassFlowSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class MomentumSettingControl : UnitSettingControl<Momentum, MomentumUnit>
    {
        public static readonly MomentumUnit DefaultUnit = MomentumUnit.NewtonSecond;

        static MomentumSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MomentumSettingControl), new FrameworkPropertyMetadata(typeof(MomentumSettingControl)));
            UnitProperty.OverrideMetadata(typeof(MomentumSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(MomentumSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class PowerSettingControl : UnitSettingControl<Power, PowerUnit>
    {
        public static readonly PowerUnit DefaultUnit = PowerUnit.Watts;

        static PowerSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PowerSettingControl), new FrameworkPropertyMetadata(typeof(PowerSettingControl)));
            UnitProperty.OverrideMetadata(typeof(PowerSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(PowerSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class PressureSettingControl : UnitSettingControl<Pressure, PressureUnit>
    {
        public static readonly PressureUnit DefaultUnit = PressureUnit.Megapascals;

        static PressureSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PressureSettingControl), new FrameworkPropertyMetadata(typeof(PressureSettingControl)));
            UnitProperty.OverrideMetadata(typeof(PressureSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(PressureSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class ResistanceSettingControl : UnitSettingControl<Resistance, ResistanceUnit>
    {
        public static readonly ResistanceUnit DefaultUnit = ResistanceUnit.Ohm;

        static ResistanceSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ResistanceSettingControl), new FrameworkPropertyMetadata(typeof(ResistanceSettingControl)));
            UnitProperty.OverrideMetadata(typeof(ResistanceSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(ResistanceSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class SolidAngleSettingControl : UnitSettingControl<SolidAngle, SolidAngleUnit>
    {
        public static readonly SolidAngleUnit DefaultUnit = SolidAngleUnit.Steradians;

        static SolidAngleSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SolidAngleSettingControl), new FrameworkPropertyMetadata(typeof(SolidAngleSettingControl)));
            UnitProperty.OverrideMetadata(typeof(SolidAngleSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(SolidAngleSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class SpecificEnergySettingControl : UnitSettingControl<SpecificEnergy, SpecificEnergyUnit>
    {
        public static readonly SpecificEnergyUnit DefaultUnit = SpecificEnergyUnit.JoulesPerKilogram;

        static SpecificEnergySettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SpecificEnergySettingControl), new FrameworkPropertyMetadata(typeof(SpecificEnergySettingControl)));
            UnitProperty.OverrideMetadata(typeof(SpecificEnergySettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(SpecificEnergySettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class SpecificVolumeSettingControl : UnitSettingControl<SpecificVolume, SpecificVolumeUnit>
    {
        public static readonly SpecificVolumeUnit DefaultUnit = SpecificVolumeUnit.CubicMetresPerKilogram;

        static SpecificVolumeSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SpecificVolumeSettingControl), new FrameworkPropertyMetadata(typeof(SpecificVolumeSettingControl)));
            UnitProperty.OverrideMetadata(typeof(SpecificVolumeSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(SpecificVolumeSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class SpeedSettingControl : UnitSettingControl<Speed, SpeedUnit>
    {
        public static readonly SpeedUnit DefaultUnit = SpeedUnit.MetresPerSecond;

        static SpeedSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SpeedSettingControl), new FrameworkPropertyMetadata(typeof(SpeedSettingControl)));
            UnitProperty.OverrideMetadata(typeof(SpeedSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(SpeedSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class StiffnessSettingControl : UnitSettingControl<Stiffness, StiffnessUnit>
    {
        public static readonly StiffnessUnit DefaultUnit = StiffnessUnit.NewtonsPerMetre;

        static StiffnessSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StiffnessSettingControl), new FrameworkPropertyMetadata(typeof(StiffnessSettingControl)));
            UnitProperty.OverrideMetadata(typeof(StiffnessSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(StiffnessSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class TemperatureSettingControl : UnitSettingControl<Temperature, TemperatureUnit>
    {
        public static readonly TemperatureUnit DefaultUnit = TemperatureUnit.Kelvin;

        static TemperatureSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TemperatureSettingControl), new FrameworkPropertyMetadata(typeof(TemperatureSettingControl)));
            UnitProperty.OverrideMetadata(typeof(TemperatureSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(TemperatureSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class TimeSettingControl : UnitSettingControl<Time, TimeUnit>
    {
        public static readonly TimeUnit DefaultUnit = TimeUnit.Seconds;

        static TimeSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimeSettingControl), new FrameworkPropertyMetadata(typeof(TimeSettingControl)));
            UnitProperty.OverrideMetadata(typeof(TimeSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(TimeSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class TorqueSettingControl : UnitSettingControl<Torque, TorqueUnit>
    {
        public static readonly TorqueUnit DefaultUnit = TorqueUnit.NewtonMetres;

        static TorqueSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TorqueSettingControl), new FrameworkPropertyMetadata(typeof(TorqueSettingControl)));
            UnitProperty.OverrideMetadata(typeof(TorqueSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(TorqueSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class UnitlessSettingControl : UnitSettingControl<Unitless, UnitlessUnit>
    {
        public static readonly UnitlessUnit DefaultUnit = UnitlessUnit.Scalar;

        static UnitlessSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UnitlessSettingControl), new FrameworkPropertyMetadata(typeof(UnitlessSettingControl)));
            UnitProperty.OverrideMetadata(typeof(UnitlessSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(UnitlessSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class VoltageSettingControl : UnitSettingControl<Voltage, VoltageUnit>
    {
        public static readonly VoltageUnit DefaultUnit = VoltageUnit.Volts;

        static VoltageSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VoltageSettingControl), new FrameworkPropertyMetadata(typeof(VoltageSettingControl)));
            UnitProperty.OverrideMetadata(typeof(VoltageSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(VoltageSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class VolumeSettingControl : UnitSettingControl<Volume, VolumeUnit>
    {
        public static readonly VolumeUnit DefaultUnit = VolumeUnit.CubicMetres;

        static VolumeSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VolumeSettingControl), new FrameworkPropertyMetadata(typeof(VolumeSettingControl)));
            UnitProperty.OverrideMetadata(typeof(VolumeSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(VolumeSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class VolumetricFlowSettingControl : UnitSettingControl<VolumetricFlow, VolumetricFlowUnit>
    {
        public static readonly VolumetricFlowUnit DefaultUnit = VolumetricFlowUnit.CubicMetresPerSecond;

        static VolumetricFlowSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VolumetricFlowSettingControl), new FrameworkPropertyMetadata(typeof(VolumetricFlowSettingControl)));
            UnitProperty.OverrideMetadata(typeof(VolumetricFlowSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(VolumetricFlowSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }

    public class WavenumberSettingControl : UnitSettingControl<Wavenumber, WavenumberUnit>
    {
        public static readonly WavenumberUnit DefaultUnit = WavenumberUnit.ReciprocalMetres;

        static WavenumberSettingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WavenumberSettingControl), new FrameworkPropertyMetadata(typeof(WavenumberSettingControl)));
            UnitProperty.OverrideMetadata(typeof(WavenumberSettingControl), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(WavenumberSettingControl),
                new FrameworkPropertyMetadata(
                    GetSuffix(DefaultUnit, 
                    UnitSettingControl.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));
        }
    }
}

