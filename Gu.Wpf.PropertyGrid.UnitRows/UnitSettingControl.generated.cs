#pragma warning disable SA1649 // File name must match first type name
#pragma warning disable SA1402 // File may only contain a single class
namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Data;
    using Gu.Units;

    public class AccelerationRow : UnitRow<Acceleration, AccelerationUnit>
    {
        public static readonly AccelerationUnit DefaultUnit = AccelerationUnit.MetresPerSecondSquared;

        static AccelerationRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AccelerationRow), new FrameworkPropertyMetadata(typeof(AccelerationRow)));
            UnitProperty.OverrideMetadata(typeof(AccelerationRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(AccelerationRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(AccelerationRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class AmountOfSubstanceRow : UnitRow<AmountOfSubstance, AmountOfSubstanceUnit>
    {
        public static readonly AmountOfSubstanceUnit DefaultUnit = AmountOfSubstanceUnit.Moles;

        static AmountOfSubstanceRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AmountOfSubstanceRow), new FrameworkPropertyMetadata(typeof(AmountOfSubstanceRow)));
            UnitProperty.OverrideMetadata(typeof(AmountOfSubstanceRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(AmountOfSubstanceRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(AmountOfSubstanceRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class AngleRow : UnitRow<Angle, AngleUnit>
    {
        public static readonly AngleUnit DefaultUnit = AngleUnit.Degrees;

        static AngleRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AngleRow), new FrameworkPropertyMetadata(typeof(AngleRow)));
            UnitProperty.OverrideMetadata(typeof(AngleRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(AngleRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(AngleRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class AnglePerUnitlessRow : UnitRow<AnglePerUnitless, AnglePerUnitlessUnit>
    {
        public static readonly AnglePerUnitlessUnit DefaultUnit = AnglePerUnitlessUnit.RadiansPerUnitless;

        static AnglePerUnitlessRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AnglePerUnitlessRow), new FrameworkPropertyMetadata(typeof(AnglePerUnitlessRow)));
            UnitProperty.OverrideMetadata(typeof(AnglePerUnitlessRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(AnglePerUnitlessRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(AnglePerUnitlessRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class AngularAccelerationRow : UnitRow<AngularAcceleration, AngularAccelerationUnit>
    {
        public static readonly AngularAccelerationUnit DefaultUnit = AngularAccelerationUnit.RadiansPerSecondSquared;

        static AngularAccelerationRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AngularAccelerationRow), new FrameworkPropertyMetadata(typeof(AngularAccelerationRow)));
            UnitProperty.OverrideMetadata(typeof(AngularAccelerationRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(AngularAccelerationRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(AngularAccelerationRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class AngularJerkRow : UnitRow<AngularJerk, AngularJerkUnit>
    {
        public static readonly AngularJerkUnit DefaultUnit = AngularJerkUnit.RadiansPerSecondCubed;

        static AngularJerkRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AngularJerkRow), new FrameworkPropertyMetadata(typeof(AngularJerkRow)));
            UnitProperty.OverrideMetadata(typeof(AngularJerkRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(AngularJerkRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(AngularJerkRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class AngularSpeedRow : UnitRow<AngularSpeed, AngularSpeedUnit>
    {
        public static readonly AngularSpeedUnit DefaultUnit = AngularSpeedUnit.RadiansPerSecond;

        static AngularSpeedRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AngularSpeedRow), new FrameworkPropertyMetadata(typeof(AngularSpeedRow)));
            UnitProperty.OverrideMetadata(typeof(AngularSpeedRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(AngularSpeedRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(AngularSpeedRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class AreaRow : UnitRow<Area, AreaUnit>
    {
        public static readonly AreaUnit DefaultUnit = AreaUnit.SquareMetres;

        static AreaRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AreaRow), new FrameworkPropertyMetadata(typeof(AreaRow)));
            UnitProperty.OverrideMetadata(typeof(AreaRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(AreaRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(AreaRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class AreaDensityRow : UnitRow<AreaDensity, AreaDensityUnit>
    {
        public static readonly AreaDensityUnit DefaultUnit = AreaDensityUnit.KilogramsPerSquareMetre;

        static AreaDensityRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AreaDensityRow), new FrameworkPropertyMetadata(typeof(AreaDensityRow)));
            UnitProperty.OverrideMetadata(typeof(AreaDensityRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(AreaDensityRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(AreaDensityRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class CapacitanceRow : UnitRow<Capacitance, CapacitanceUnit>
    {
        public static readonly CapacitanceUnit DefaultUnit = CapacitanceUnit.Farads;

        static CapacitanceRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CapacitanceRow), new FrameworkPropertyMetadata(typeof(CapacitanceRow)));
            UnitProperty.OverrideMetadata(typeof(CapacitanceRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(CapacitanceRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(CapacitanceRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class CatalyticActivityRow : UnitRow<CatalyticActivity, CatalyticActivityUnit>
    {
        public static readonly CatalyticActivityUnit DefaultUnit = CatalyticActivityUnit.Katals;

        static CatalyticActivityRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CatalyticActivityRow), new FrameworkPropertyMetadata(typeof(CatalyticActivityRow)));
            UnitProperty.OverrideMetadata(typeof(CatalyticActivityRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(CatalyticActivityRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(CatalyticActivityRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class CurrentRow : UnitRow<Current, CurrentUnit>
    {
        public static readonly CurrentUnit DefaultUnit = CurrentUnit.Amperes;

        static CurrentRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CurrentRow), new FrameworkPropertyMetadata(typeof(CurrentRow)));
            UnitProperty.OverrideMetadata(typeof(CurrentRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(CurrentRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(CurrentRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class DataRow : UnitRow<Data, DataUnit>
    {
        public static readonly DataUnit DefaultUnit = DataUnit.Bits;

        static DataRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DataRow), new FrameworkPropertyMetadata(typeof(DataRow)));
            UnitProperty.OverrideMetadata(typeof(DataRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(DataRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(DataRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class DensityRow : UnitRow<Density, DensityUnit>
    {
        public static readonly DensityUnit DefaultUnit = DensityUnit.KilogramsPerCubicMetre;

        static DensityRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DensityRow), new FrameworkPropertyMetadata(typeof(DensityRow)));
            UnitProperty.OverrideMetadata(typeof(DensityRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(DensityRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(DensityRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class ElectricalConductanceRow : UnitRow<ElectricalConductance, ElectricalConductanceUnit>
    {
        public static readonly ElectricalConductanceUnit DefaultUnit = ElectricalConductanceUnit.Siemens;

        static ElectricalConductanceRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ElectricalConductanceRow), new FrameworkPropertyMetadata(typeof(ElectricalConductanceRow)));
            UnitProperty.OverrideMetadata(typeof(ElectricalConductanceRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(ElectricalConductanceRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(ElectricalConductanceRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class ElectricChargeRow : UnitRow<ElectricCharge, ElectricChargeUnit>
    {
        public static readonly ElectricChargeUnit DefaultUnit = ElectricChargeUnit.Coulombs;

        static ElectricChargeRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ElectricChargeRow), new FrameworkPropertyMetadata(typeof(ElectricChargeRow)));
            UnitProperty.OverrideMetadata(typeof(ElectricChargeRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(ElectricChargeRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(ElectricChargeRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class EnergyRow : UnitRow<Energy, EnergyUnit>
    {
        public static readonly EnergyUnit DefaultUnit = EnergyUnit.Joules;

        static EnergyRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EnergyRow), new FrameworkPropertyMetadata(typeof(EnergyRow)));
            UnitProperty.OverrideMetadata(typeof(EnergyRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(EnergyRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(EnergyRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class FlexibilityRow : UnitRow<Flexibility, FlexibilityUnit>
    {
        public static readonly FlexibilityUnit DefaultUnit = FlexibilityUnit.MetresPerNewton;

        static FlexibilityRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlexibilityRow), new FrameworkPropertyMetadata(typeof(FlexibilityRow)));
            UnitProperty.OverrideMetadata(typeof(FlexibilityRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(FlexibilityRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(FlexibilityRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class ForceRow : UnitRow<Force, ForceUnit>
    {
        public static readonly ForceUnit DefaultUnit = ForceUnit.Newtons;

        static ForceRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ForceRow), new FrameworkPropertyMetadata(typeof(ForceRow)));
            UnitProperty.OverrideMetadata(typeof(ForceRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(ForceRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(ForceRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class ForcePerUnitlessRow : UnitRow<ForcePerUnitless, ForcePerUnitlessUnit>
    {
        public static readonly ForcePerUnitlessUnit DefaultUnit = ForcePerUnitlessUnit.NewtonsPerUnitless;

        static ForcePerUnitlessRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ForcePerUnitlessRow), new FrameworkPropertyMetadata(typeof(ForcePerUnitlessRow)));
            UnitProperty.OverrideMetadata(typeof(ForcePerUnitlessRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(ForcePerUnitlessRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(ForcePerUnitlessRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class FrequencyRow : UnitRow<Frequency, FrequencyUnit>
    {
        public static readonly FrequencyUnit DefaultUnit = FrequencyUnit.Hertz;

        static FrequencyRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FrequencyRow), new FrameworkPropertyMetadata(typeof(FrequencyRow)));
            UnitProperty.OverrideMetadata(typeof(FrequencyRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(FrequencyRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(FrequencyRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class IlluminanceRow : UnitRow<Illuminance, IlluminanceUnit>
    {
        public static readonly IlluminanceUnit DefaultUnit = IlluminanceUnit.Lux;

        static IlluminanceRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IlluminanceRow), new FrameworkPropertyMetadata(typeof(IlluminanceRow)));
            UnitProperty.OverrideMetadata(typeof(IlluminanceRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(IlluminanceRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(IlluminanceRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class InductanceRow : UnitRow<Inductance, InductanceUnit>
    {
        public static readonly InductanceUnit DefaultUnit = InductanceUnit.Henrys;

        static InductanceRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(InductanceRow), new FrameworkPropertyMetadata(typeof(InductanceRow)));
            UnitProperty.OverrideMetadata(typeof(InductanceRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(InductanceRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(InductanceRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class JerkRow : UnitRow<Jerk, JerkUnit>
    {
        public static readonly JerkUnit DefaultUnit = JerkUnit.MetresPerSecondCubed;

        static JerkRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(JerkRow), new FrameworkPropertyMetadata(typeof(JerkRow)));
            UnitProperty.OverrideMetadata(typeof(JerkRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(JerkRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(JerkRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class KinematicViscosityRow : UnitRow<KinematicViscosity, KinematicViscosityUnit>
    {
        public static readonly KinematicViscosityUnit DefaultUnit = KinematicViscosityUnit.SquareMetresPerSecond;

        static KinematicViscosityRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(KinematicViscosityRow), new FrameworkPropertyMetadata(typeof(KinematicViscosityRow)));
            UnitProperty.OverrideMetadata(typeof(KinematicViscosityRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(KinematicViscosityRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(KinematicViscosityRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class LengthRow : UnitRow<Length, LengthUnit>
    {
        public static readonly LengthUnit DefaultUnit = LengthUnit.Millimetres;

        static LengthRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LengthRow), new FrameworkPropertyMetadata(typeof(LengthRow)));
            UnitProperty.OverrideMetadata(typeof(LengthRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(LengthRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(LengthRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class LengthPerUnitlessRow : UnitRow<LengthPerUnitless, LengthPerUnitlessUnit>
    {
        public static readonly LengthPerUnitlessUnit DefaultUnit = LengthPerUnitlessUnit.MetresPerUnitless;

        static LengthPerUnitlessRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LengthPerUnitlessRow), new FrameworkPropertyMetadata(typeof(LengthPerUnitlessRow)));
            UnitProperty.OverrideMetadata(typeof(LengthPerUnitlessRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(LengthPerUnitlessRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(LengthPerUnitlessRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class LuminousFluxRow : UnitRow<LuminousFlux, LuminousFluxUnit>
    {
        public static readonly LuminousFluxUnit DefaultUnit = LuminousFluxUnit.Lumens;

        static LuminousFluxRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LuminousFluxRow), new FrameworkPropertyMetadata(typeof(LuminousFluxRow)));
            UnitProperty.OverrideMetadata(typeof(LuminousFluxRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(LuminousFluxRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(LuminousFluxRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class LuminousIntensityRow : UnitRow<LuminousIntensity, LuminousIntensityUnit>
    {
        public static readonly LuminousIntensityUnit DefaultUnit = LuminousIntensityUnit.Candelas;

        static LuminousIntensityRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LuminousIntensityRow), new FrameworkPropertyMetadata(typeof(LuminousIntensityRow)));
            UnitProperty.OverrideMetadata(typeof(LuminousIntensityRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(LuminousIntensityRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(LuminousIntensityRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class MagneticFieldStrengthRow : UnitRow<MagneticFieldStrength, MagneticFieldStrengthUnit>
    {
        public static readonly MagneticFieldStrengthUnit DefaultUnit = MagneticFieldStrengthUnit.Teslas;

        static MagneticFieldStrengthRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MagneticFieldStrengthRow), new FrameworkPropertyMetadata(typeof(MagneticFieldStrengthRow)));
            UnitProperty.OverrideMetadata(typeof(MagneticFieldStrengthRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(MagneticFieldStrengthRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(MagneticFieldStrengthRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class MagneticFluxRow : UnitRow<MagneticFlux, MagneticFluxUnit>
    {
        public static readonly MagneticFluxUnit DefaultUnit = MagneticFluxUnit.Webers;

        static MagneticFluxRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MagneticFluxRow), new FrameworkPropertyMetadata(typeof(MagneticFluxRow)));
            UnitProperty.OverrideMetadata(typeof(MagneticFluxRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(MagneticFluxRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(MagneticFluxRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class MassRow : UnitRow<Mass, MassUnit>
    {
        public static readonly MassUnit DefaultUnit = MassUnit.Kilograms;

        static MassRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MassRow), new FrameworkPropertyMetadata(typeof(MassRow)));
            UnitProperty.OverrideMetadata(typeof(MassRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(MassRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(MassRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class MassFlowRow : UnitRow<MassFlow, MassFlowUnit>
    {
        public static readonly MassFlowUnit DefaultUnit = MassFlowUnit.KilogramsPerSecond;

        static MassFlowRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MassFlowRow), new FrameworkPropertyMetadata(typeof(MassFlowRow)));
            UnitProperty.OverrideMetadata(typeof(MassFlowRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(MassFlowRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(MassFlowRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class MomentumRow : UnitRow<Momentum, MomentumUnit>
    {
        public static readonly MomentumUnit DefaultUnit = MomentumUnit.NewtonSecond;

        static MomentumRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MomentumRow), new FrameworkPropertyMetadata(typeof(MomentumRow)));
            UnitProperty.OverrideMetadata(typeof(MomentumRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(MomentumRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(MomentumRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class PowerRow : UnitRow<Power, PowerUnit>
    {
        public static readonly PowerUnit DefaultUnit = PowerUnit.Watts;

        static PowerRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PowerRow), new FrameworkPropertyMetadata(typeof(PowerRow)));
            UnitProperty.OverrideMetadata(typeof(PowerRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(PowerRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(PowerRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class PressureRow : UnitRow<Pressure, PressureUnit>
    {
        public static readonly PressureUnit DefaultUnit = PressureUnit.Megapascals;

        static PressureRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PressureRow), new FrameworkPropertyMetadata(typeof(PressureRow)));
            UnitProperty.OverrideMetadata(typeof(PressureRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(PressureRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(PressureRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class ResistanceRow : UnitRow<Resistance, ResistanceUnit>
    {
        public static readonly ResistanceUnit DefaultUnit = ResistanceUnit.Ohms;

        static ResistanceRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ResistanceRow), new FrameworkPropertyMetadata(typeof(ResistanceRow)));
            UnitProperty.OverrideMetadata(typeof(ResistanceRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(ResistanceRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(ResistanceRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class SolidAngleRow : UnitRow<SolidAngle, SolidAngleUnit>
    {
        public static readonly SolidAngleUnit DefaultUnit = SolidAngleUnit.Steradians;

        static SolidAngleRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SolidAngleRow), new FrameworkPropertyMetadata(typeof(SolidAngleRow)));
            UnitProperty.OverrideMetadata(typeof(SolidAngleRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(SolidAngleRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(SolidAngleRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class SpecificEnergyRow : UnitRow<SpecificEnergy, SpecificEnergyUnit>
    {
        public static readonly SpecificEnergyUnit DefaultUnit = SpecificEnergyUnit.JoulesPerKilogram;

        static SpecificEnergyRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SpecificEnergyRow), new FrameworkPropertyMetadata(typeof(SpecificEnergyRow)));
            UnitProperty.OverrideMetadata(typeof(SpecificEnergyRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(SpecificEnergyRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(SpecificEnergyRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class SpecificVolumeRow : UnitRow<SpecificVolume, SpecificVolumeUnit>
    {
        public static readonly SpecificVolumeUnit DefaultUnit = SpecificVolumeUnit.CubicMetresPerKilogram;

        static SpecificVolumeRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SpecificVolumeRow), new FrameworkPropertyMetadata(typeof(SpecificVolumeRow)));
            UnitProperty.OverrideMetadata(typeof(SpecificVolumeRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(SpecificVolumeRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(SpecificVolumeRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class SpeedRow : UnitRow<Speed, SpeedUnit>
    {
        public static readonly SpeedUnit DefaultUnit = SpeedUnit.MetresPerSecond;

        static SpeedRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SpeedRow), new FrameworkPropertyMetadata(typeof(SpeedRow)));
            UnitProperty.OverrideMetadata(typeof(SpeedRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(SpeedRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(SpeedRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class StiffnessRow : UnitRow<Stiffness, StiffnessUnit>
    {
        public static readonly StiffnessUnit DefaultUnit = StiffnessUnit.NewtonsPerMetre;

        static StiffnessRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StiffnessRow), new FrameworkPropertyMetadata(typeof(StiffnessRow)));
            UnitProperty.OverrideMetadata(typeof(StiffnessRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(StiffnessRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(StiffnessRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class TemperatureRow : UnitRow<Temperature, TemperatureUnit>
    {
        public static readonly TemperatureUnit DefaultUnit = TemperatureUnit.Kelvin;

        static TemperatureRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TemperatureRow), new FrameworkPropertyMetadata(typeof(TemperatureRow)));
            UnitProperty.OverrideMetadata(typeof(TemperatureRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(TemperatureRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(TemperatureRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class TimeRow : UnitRow<Time, TimeUnit>
    {
        public static readonly TimeUnit DefaultUnit = TimeUnit.Seconds;

        static TimeRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimeRow), new FrameworkPropertyMetadata(typeof(TimeRow)));
            UnitProperty.OverrideMetadata(typeof(TimeRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(TimeRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(TimeRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class TorqueRow : UnitRow<Torque, TorqueUnit>
    {
        public static readonly TorqueUnit DefaultUnit = TorqueUnit.NewtonMetres;

        static TorqueRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TorqueRow), new FrameworkPropertyMetadata(typeof(TorqueRow)));
            UnitProperty.OverrideMetadata(typeof(TorqueRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(TorqueRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(TorqueRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class UnitlessRow : UnitRow<Unitless, UnitlessUnit>
    {
        public static readonly UnitlessUnit DefaultUnit = UnitlessUnit.Scalar;

        static UnitlessRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UnitlessRow), new FrameworkPropertyMetadata(typeof(UnitlessRow)));
            UnitProperty.OverrideMetadata(typeof(UnitlessRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(UnitlessRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(UnitlessRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class VoltageRow : UnitRow<Voltage, VoltageUnit>
    {
        public static readonly VoltageUnit DefaultUnit = VoltageUnit.Volts;

        static VoltageRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VoltageRow), new FrameworkPropertyMetadata(typeof(VoltageRow)));
            UnitProperty.OverrideMetadata(typeof(VoltageRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(VoltageRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(VoltageRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class VolumeRow : UnitRow<Volume, VolumeUnit>
    {
        public static readonly VolumeUnit DefaultUnit = VolumeUnit.CubicMetres;

        static VolumeRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VolumeRow), new FrameworkPropertyMetadata(typeof(VolumeRow)));
            UnitProperty.OverrideMetadata(typeof(VolumeRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(VolumeRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(VolumeRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class VolumetricFlowRow : UnitRow<VolumetricFlow, VolumetricFlowUnit>
    {
        public static readonly VolumetricFlowUnit DefaultUnit = VolumetricFlowUnit.CubicMetresPerSecond;

        static VolumetricFlowRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VolumetricFlowRow), new FrameworkPropertyMetadata(typeof(VolumetricFlowRow)));
            UnitProperty.OverrideMetadata(typeof(VolumetricFlowRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(VolumetricFlowRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(VolumetricFlowRow), UpdateSourceTrigger.LostFocus);
        }
    }

    public class WavenumberRow : UnitRow<Wavenumber, WavenumberUnit>
    {
        public static readonly WavenumberUnit DefaultUnit = WavenumberUnit.ReciprocalMetres;

        static WavenumberRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WavenumberRow), new FrameworkPropertyMetadata(typeof(WavenumberRow)));
            UnitProperty.OverrideMetadata(typeof(WavenumberRow), new PropertyMetadata(DefaultUnit, OnUnitChanged));
            SuffixProperty.OverrideMetadata(
                typeof(WavenumberRow),
                new FrameworkPropertyMetadata(
                    CreateSuffix(DefaultUnit, UnitRow.DefaultSymbolFormat),
                    FrameworkPropertyMetadataOptions.NotDataBindable));

            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(WavenumberRow), UpdateSourceTrigger.LostFocus);
        }
    }
}
