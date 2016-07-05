#pragma warning disable SA1649 // File name must match first type name
#pragma warning disable SA1402 // File may only contain a single class
#pragma warning disable SA1118 // Parameter must not span multiple lines
namespace Gu.Wpf.PropertyGrid.UnitRows
{
    using System.Windows;
    using System.Windows.Data;
    using Gu.Units;

    public class AccelerationRow : UnitRowGeneric<Acceleration, AccelerationUnit>
    {
        public static readonly AccelerationUnit DefaultUnit = default(AccelerationUnit).SiUnit;

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

    public class AmountOfSubstanceRow : UnitRowGeneric<AmountOfSubstance, AmountOfSubstanceUnit>
    {
        public static readonly AmountOfSubstanceUnit DefaultUnit = default(AmountOfSubstanceUnit).SiUnit;

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

    public class AngleRow : UnitRowGeneric<Angle, AngleUnit>
    {
        public static readonly AngleUnit DefaultUnit = default(AngleUnit).SiUnit;

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

    public class AnglePerUnitlessRow : UnitRowGeneric<AnglePerUnitless, AnglePerUnitlessUnit>
    {
        public static readonly AnglePerUnitlessUnit DefaultUnit = default(AnglePerUnitlessUnit).SiUnit;

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

    public class AngularAccelerationRow : UnitRowGeneric<AngularAcceleration, AngularAccelerationUnit>
    {
        public static readonly AngularAccelerationUnit DefaultUnit = default(AngularAccelerationUnit).SiUnit;

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

    public class AngularJerkRow : UnitRowGeneric<AngularJerk, AngularJerkUnit>
    {
        public static readonly AngularJerkUnit DefaultUnit = default(AngularJerkUnit).SiUnit;

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

    public class AngularSpeedRow : UnitRowGeneric<AngularSpeed, AngularSpeedUnit>
    {
        public static readonly AngularSpeedUnit DefaultUnit = default(AngularSpeedUnit).SiUnit;

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

    public class AreaRow : UnitRowGeneric<Area, AreaUnit>
    {
        public static readonly AreaUnit DefaultUnit = default(AreaUnit).SiUnit;

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

    public class AreaDensityRow : UnitRowGeneric<AreaDensity, AreaDensityUnit>
    {
        public static readonly AreaDensityUnit DefaultUnit = default(AreaDensityUnit).SiUnit;

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

    public class CapacitanceRow : UnitRowGeneric<Capacitance, CapacitanceUnit>
    {
        public static readonly CapacitanceUnit DefaultUnit = default(CapacitanceUnit).SiUnit;

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

    public class CatalyticActivityRow : UnitRowGeneric<CatalyticActivity, CatalyticActivityUnit>
    {
        public static readonly CatalyticActivityUnit DefaultUnit = default(CatalyticActivityUnit).SiUnit;

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

    public class CurrentRow : UnitRowGeneric<Current, CurrentUnit>
    {
        public static readonly CurrentUnit DefaultUnit = default(CurrentUnit).SiUnit;

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

    public class DataRow : UnitRowGeneric<Data, DataUnit>
    {
        public static readonly DataUnit DefaultUnit = default(DataUnit).SiUnit;

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

    public class DensityRow : UnitRowGeneric<Density, DensityUnit>
    {
        public static readonly DensityUnit DefaultUnit = default(DensityUnit).SiUnit;

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

    public class ElectricalConductanceRow : UnitRowGeneric<ElectricalConductance, ElectricalConductanceUnit>
    {
        public static readonly ElectricalConductanceUnit DefaultUnit = default(ElectricalConductanceUnit).SiUnit;

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

    public class ElectricChargeRow : UnitRowGeneric<ElectricCharge, ElectricChargeUnit>
    {
        public static readonly ElectricChargeUnit DefaultUnit = default(ElectricChargeUnit).SiUnit;

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

    public class EnergyRow : UnitRowGeneric<Energy, EnergyUnit>
    {
        public static readonly EnergyUnit DefaultUnit = default(EnergyUnit).SiUnit;

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

    public class FlexibilityRow : UnitRowGeneric<Flexibility, FlexibilityUnit>
    {
        public static readonly FlexibilityUnit DefaultUnit = default(FlexibilityUnit).SiUnit;

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

    public class ForceRow : UnitRowGeneric<Force, ForceUnit>
    {
        public static readonly ForceUnit DefaultUnit = default(ForceUnit).SiUnit;

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

    public class ForcePerUnitlessRow : UnitRowGeneric<ForcePerUnitless, ForcePerUnitlessUnit>
    {
        public static readonly ForcePerUnitlessUnit DefaultUnit = default(ForcePerUnitlessUnit).SiUnit;

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

    public class FrequencyRow : UnitRowGeneric<Frequency, FrequencyUnit>
    {
        public static readonly FrequencyUnit DefaultUnit = default(FrequencyUnit).SiUnit;

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

    public class IlluminanceRow : UnitRowGeneric<Illuminance, IlluminanceUnit>
    {
        public static readonly IlluminanceUnit DefaultUnit = default(IlluminanceUnit).SiUnit;

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

    public class InductanceRow : UnitRowGeneric<Inductance, InductanceUnit>
    {
        public static readonly InductanceUnit DefaultUnit = default(InductanceUnit).SiUnit;

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

    public class JerkRow : UnitRowGeneric<Jerk, JerkUnit>
    {
        public static readonly JerkUnit DefaultUnit = default(JerkUnit).SiUnit;

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

    public class KinematicViscosityRow : UnitRowGeneric<KinematicViscosity, KinematicViscosityUnit>
    {
        public static readonly KinematicViscosityUnit DefaultUnit = default(KinematicViscosityUnit).SiUnit;

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

    public class LengthRow : UnitRowGeneric<Length, LengthUnit>
    {
        public static readonly LengthUnit DefaultUnit = default(LengthUnit).SiUnit;

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

    public class LengthPerUnitlessRow : UnitRowGeneric<LengthPerUnitless, LengthPerUnitlessUnit>
    {
        public static readonly LengthPerUnitlessUnit DefaultUnit = default(LengthPerUnitlessUnit).SiUnit;

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

    public class LuminousFluxRow : UnitRowGeneric<LuminousFlux, LuminousFluxUnit>
    {
        public static readonly LuminousFluxUnit DefaultUnit = default(LuminousFluxUnit).SiUnit;

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

    public class LuminousIntensityRow : UnitRowGeneric<LuminousIntensity, LuminousIntensityUnit>
    {
        public static readonly LuminousIntensityUnit DefaultUnit = default(LuminousIntensityUnit).SiUnit;

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

    public class MagneticFieldStrengthRow : UnitRowGeneric<MagneticFieldStrength, MagneticFieldStrengthUnit>
    {
        public static readonly MagneticFieldStrengthUnit DefaultUnit = default(MagneticFieldStrengthUnit).SiUnit;

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

    public class MagneticFluxRow : UnitRowGeneric<MagneticFlux, MagneticFluxUnit>
    {
        public static readonly MagneticFluxUnit DefaultUnit = default(MagneticFluxUnit).SiUnit;

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

    public class MassRow : UnitRowGeneric<Mass, MassUnit>
    {
        public static readonly MassUnit DefaultUnit = default(MassUnit).SiUnit;

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

    public class MassFlowRow : UnitRowGeneric<MassFlow, MassFlowUnit>
    {
        public static readonly MassFlowUnit DefaultUnit = default(MassFlowUnit).SiUnit;

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

    public class MomentumRow : UnitRowGeneric<Momentum, MomentumUnit>
    {
        public static readonly MomentumUnit DefaultUnit = default(MomentumUnit).SiUnit;

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

    public class PowerRow : UnitRowGeneric<Power, PowerUnit>
    {
        public static readonly PowerUnit DefaultUnit = default(PowerUnit).SiUnit;

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

    public class PressureRow : UnitRowGeneric<Pressure, PressureUnit>
    {
        public static readonly PressureUnit DefaultUnit = default(PressureUnit).SiUnit;

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

    public class ResistanceRow : UnitRowGeneric<Resistance, ResistanceUnit>
    {
        public static readonly ResistanceUnit DefaultUnit = default(ResistanceUnit).SiUnit;

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

    public class SolidAngleRow : UnitRowGeneric<SolidAngle, SolidAngleUnit>
    {
        public static readonly SolidAngleUnit DefaultUnit = default(SolidAngleUnit).SiUnit;

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

    public class SpecificEnergyRow : UnitRowGeneric<SpecificEnergy, SpecificEnergyUnit>
    {
        public static readonly SpecificEnergyUnit DefaultUnit = default(SpecificEnergyUnit).SiUnit;

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

    public class SpecificVolumeRow : UnitRowGeneric<SpecificVolume, SpecificVolumeUnit>
    {
        public static readonly SpecificVolumeUnit DefaultUnit = default(SpecificVolumeUnit).SiUnit;

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

    public class SpeedRow : UnitRowGeneric<Speed, SpeedUnit>
    {
        public static readonly SpeedUnit DefaultUnit = default(SpeedUnit).SiUnit;

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

    public class StiffnessRow : UnitRowGeneric<Stiffness, StiffnessUnit>
    {
        public static readonly StiffnessUnit DefaultUnit = default(StiffnessUnit).SiUnit;

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

    public class TemperatureRow : UnitRowGeneric<Temperature, TemperatureUnit>
    {
        public static readonly TemperatureUnit DefaultUnit = default(TemperatureUnit).SiUnit;

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

    public class TimeRow : UnitRowGeneric<Time, TimeUnit>
    {
        public static readonly TimeUnit DefaultUnit = default(TimeUnit).SiUnit;

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

    public class TorqueRow : UnitRowGeneric<Torque, TorqueUnit>
    {
        public static readonly TorqueUnit DefaultUnit = default(TorqueUnit).SiUnit;

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

    public class UnitlessRow : UnitRowGeneric<Unitless, UnitlessUnit>
    {
        public static readonly UnitlessUnit DefaultUnit = default(UnitlessUnit).SiUnit;

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

    public class VoltageRow : UnitRowGeneric<Voltage, VoltageUnit>
    {
        public static readonly VoltageUnit DefaultUnit = default(VoltageUnit).SiUnit;

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

    public class VolumeRow : UnitRowGeneric<Volume, VolumeUnit>
    {
        public static readonly VolumeUnit DefaultUnit = default(VolumeUnit).SiUnit;

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

    public class VolumetricFlowRow : UnitRowGeneric<VolumetricFlow, VolumetricFlowUnit>
    {
        public static readonly VolumetricFlowUnit DefaultUnit = default(VolumetricFlowUnit).SiUnit;

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

    public class WavenumberRow : UnitRowGeneric<Wavenumber, WavenumberUnit>
    {
        public static readonly WavenumberUnit DefaultUnit = default(WavenumberUnit).SiUnit;

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
