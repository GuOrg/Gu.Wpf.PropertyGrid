#pragma warning disable SA1649 // File name must match first type name
#pragma warning disable SA1402 // File may only contain a single class
namespace Gu.Wpf.PropertyGrid.UnitRows
{
    using System.Windows;
    using Gu.Units;

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Acceleration"/>
    /// </summary>
    public class AccelerationRow : UnitRow<Acceleration, AccelerationUnit>
    {
        static AccelerationRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AccelerationRow), new FrameworkPropertyMetadata(typeof(AccelerationRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="AmountOfSubstance"/>
    /// </summary>
    public class AmountOfSubstanceRow : UnitRow<AmountOfSubstance, AmountOfSubstanceUnit>
    {
        static AmountOfSubstanceRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AmountOfSubstanceRow), new FrameworkPropertyMetadata(typeof(AmountOfSubstanceRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Angle"/>
    /// </summary>
    public class AngleRow : UnitRow<Angle, AngleUnit>
    {
        static AngleRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AngleRow), new FrameworkPropertyMetadata(typeof(AngleRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="AnglePerUnitless"/>
    /// </summary>
    public class AnglePerUnitlessRow : UnitRow<AnglePerUnitless, AnglePerUnitlessUnit>
    {
        static AnglePerUnitlessRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AnglePerUnitlessRow), new FrameworkPropertyMetadata(typeof(AnglePerUnitlessRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="AngularAcceleration"/>
    /// </summary>
    public class AngularAccelerationRow : UnitRow<AngularAcceleration, AngularAccelerationUnit>
    {
        static AngularAccelerationRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AngularAccelerationRow), new FrameworkPropertyMetadata(typeof(AngularAccelerationRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="AngularJerk"/>
    /// </summary>
    public class AngularJerkRow : UnitRow<AngularJerk, AngularJerkUnit>
    {
        static AngularJerkRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AngularJerkRow), new FrameworkPropertyMetadata(typeof(AngularJerkRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="AngularSpeed"/>
    /// </summary>
    public class AngularSpeedRow : UnitRow<AngularSpeed, AngularSpeedUnit>
    {
        static AngularSpeedRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AngularSpeedRow), new FrameworkPropertyMetadata(typeof(AngularSpeedRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Area"/>
    /// </summary>
    public class AreaRow : UnitRow<Area, AreaUnit>
    {
        static AreaRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AreaRow), new FrameworkPropertyMetadata(typeof(AreaRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="AreaDensity"/>
    /// </summary>
    public class AreaDensityRow : UnitRow<AreaDensity, AreaDensityUnit>
    {
        static AreaDensityRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AreaDensityRow), new FrameworkPropertyMetadata(typeof(AreaDensityRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Capacitance"/>
    /// </summary>
    public class CapacitanceRow : UnitRow<Capacitance, CapacitanceUnit>
    {
        static CapacitanceRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CapacitanceRow), new FrameworkPropertyMetadata(typeof(CapacitanceRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="CatalyticActivity"/>
    /// </summary>
    public class CatalyticActivityRow : UnitRow<CatalyticActivity, CatalyticActivityUnit>
    {
        static CatalyticActivityRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CatalyticActivityRow), new FrameworkPropertyMetadata(typeof(CatalyticActivityRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Conductivity"/>
    /// </summary>
    public class ConductivityRow : UnitRow<Conductivity, ConductivityUnit>
    {
        static ConductivityRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ConductivityRow), new FrameworkPropertyMetadata(typeof(ConductivityRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Current"/>
    /// </summary>
    public class CurrentRow : UnitRow<Current, CurrentUnit>
    {
        static CurrentRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CurrentRow), new FrameworkPropertyMetadata(typeof(CurrentRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Data"/>
    /// </summary>
    public class DataRow : UnitRow<Data, DataUnit>
    {
        static DataRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DataRow), new FrameworkPropertyMetadata(typeof(DataRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Density"/>
    /// </summary>
    public class DensityRow : UnitRow<Density, DensityUnit>
    {
        static DensityRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DensityRow), new FrameworkPropertyMetadata(typeof(DensityRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="ElectricalConductance"/>
    /// </summary>
    public class ElectricalConductanceRow : UnitRow<ElectricalConductance, ElectricalConductanceUnit>
    {
        static ElectricalConductanceRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ElectricalConductanceRow), new FrameworkPropertyMetadata(typeof(ElectricalConductanceRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="ElectricCharge"/>
    /// </summary>
    public class ElectricChargeRow : UnitRow<ElectricCharge, ElectricChargeUnit>
    {
        static ElectricChargeRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ElectricChargeRow), new FrameworkPropertyMetadata(typeof(ElectricChargeRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Energy"/>
    /// </summary>
    public class EnergyRow : UnitRow<Energy, EnergyUnit>
    {
        static EnergyRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EnergyRow), new FrameworkPropertyMetadata(typeof(EnergyRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Flexibility"/>
    /// </summary>
    public class FlexibilityRow : UnitRow<Flexibility, FlexibilityUnit>
    {
        static FlexibilityRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlexibilityRow), new FrameworkPropertyMetadata(typeof(FlexibilityRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Force"/>
    /// </summary>
    public class ForceRow : UnitRow<Force, ForceUnit>
    {
        static ForceRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ForceRow), new FrameworkPropertyMetadata(typeof(ForceRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="ForcePerUnitless"/>
    /// </summary>
    public class ForcePerUnitlessRow : UnitRow<ForcePerUnitless, ForcePerUnitlessUnit>
    {
        static ForcePerUnitlessRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ForcePerUnitlessRow), new FrameworkPropertyMetadata(typeof(ForcePerUnitlessRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Frequency"/>
    /// </summary>
    public class FrequencyRow : UnitRow<Frequency, FrequencyUnit>
    {
        static FrequencyRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FrequencyRow), new FrameworkPropertyMetadata(typeof(FrequencyRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Illuminance"/>
    /// </summary>
    public class IlluminanceRow : UnitRow<Illuminance, IlluminanceUnit>
    {
        static IlluminanceRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IlluminanceRow), new FrameworkPropertyMetadata(typeof(IlluminanceRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Inductance"/>
    /// </summary>
    public class InductanceRow : UnitRow<Inductance, InductanceUnit>
    {
        static InductanceRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(InductanceRow), new FrameworkPropertyMetadata(typeof(InductanceRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Jerk"/>
    /// </summary>
    public class JerkRow : UnitRow<Jerk, JerkUnit>
    {
        static JerkRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(JerkRow), new FrameworkPropertyMetadata(typeof(JerkRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="KinematicViscosity"/>
    /// </summary>
    public class KinematicViscosityRow : UnitRow<KinematicViscosity, KinematicViscosityUnit>
    {
        static KinematicViscosityRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(KinematicViscosityRow), new FrameworkPropertyMetadata(typeof(KinematicViscosityRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Length"/>
    /// </summary>
    public class LengthRow : UnitRow<Length, LengthUnit>
    {
        static LengthRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LengthRow), new FrameworkPropertyMetadata(typeof(LengthRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="LengthPerUnitless"/>
    /// </summary>
    public class LengthPerUnitlessRow : UnitRow<LengthPerUnitless, LengthPerUnitlessUnit>
    {
        static LengthPerUnitlessRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LengthPerUnitlessRow), new FrameworkPropertyMetadata(typeof(LengthPerUnitlessRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="LuminousFlux"/>
    /// </summary>
    public class LuminousFluxRow : UnitRow<LuminousFlux, LuminousFluxUnit>
    {
        static LuminousFluxRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LuminousFluxRow), new FrameworkPropertyMetadata(typeof(LuminousFluxRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="LuminousIntensity"/>
    /// </summary>
    public class LuminousIntensityRow : UnitRow<LuminousIntensity, LuminousIntensityUnit>
    {
        static LuminousIntensityRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LuminousIntensityRow), new FrameworkPropertyMetadata(typeof(LuminousIntensityRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="MagneticFieldStrength"/>
    /// </summary>
    public class MagneticFieldStrengthRow : UnitRow<MagneticFieldStrength, MagneticFieldStrengthUnit>
    {
        static MagneticFieldStrengthRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MagneticFieldStrengthRow), new FrameworkPropertyMetadata(typeof(MagneticFieldStrengthRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="MagneticFlux"/>
    /// </summary>
    public class MagneticFluxRow : UnitRow<MagneticFlux, MagneticFluxUnit>
    {
        static MagneticFluxRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MagneticFluxRow), new FrameworkPropertyMetadata(typeof(MagneticFluxRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Mass"/>
    /// </summary>
    public class MassRow : UnitRow<Mass, MassUnit>
    {
        static MassRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MassRow), new FrameworkPropertyMetadata(typeof(MassRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="MassFlow"/>
    /// </summary>
    public class MassFlowRow : UnitRow<MassFlow, MassFlowUnit>
    {
        static MassFlowRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MassFlowRow), new FrameworkPropertyMetadata(typeof(MassFlowRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="MolarHeatCapacity"/>
    /// </summary>
    public class MolarHeatCapacityRow : UnitRow<MolarHeatCapacity, MolarHeatCapacityUnit>
    {
        static MolarHeatCapacityRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MolarHeatCapacityRow), new FrameworkPropertyMetadata(typeof(MolarHeatCapacityRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="MolarMass"/>
    /// </summary>
    public class MolarMassRow : UnitRow<MolarMass, MolarMassUnit>
    {
        static MolarMassRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MolarMassRow), new FrameworkPropertyMetadata(typeof(MolarMassRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Momentum"/>
    /// </summary>
    public class MomentumRow : UnitRow<Momentum, MomentumUnit>
    {
        static MomentumRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MomentumRow), new FrameworkPropertyMetadata(typeof(MomentumRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Power"/>
    /// </summary>
    public class PowerRow : UnitRow<Power, PowerUnit>
    {
        static PowerRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PowerRow), new FrameworkPropertyMetadata(typeof(PowerRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Pressure"/>
    /// </summary>
    public class PressureRow : UnitRow<Pressure, PressureUnit>
    {
        static PressureRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PressureRow), new FrameworkPropertyMetadata(typeof(PressureRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Resistance"/>
    /// </summary>
    public class ResistanceRow : UnitRow<Resistance, ResistanceUnit>
    {
        static ResistanceRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ResistanceRow), new FrameworkPropertyMetadata(typeof(ResistanceRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="SolidAngle"/>
    /// </summary>
    public class SolidAngleRow : UnitRow<SolidAngle, SolidAngleUnit>
    {
        static SolidAngleRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SolidAngleRow), new FrameworkPropertyMetadata(typeof(SolidAngleRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="SpecificEnergy"/>
    /// </summary>
    public class SpecificEnergyRow : UnitRow<SpecificEnergy, SpecificEnergyUnit>
    {
        static SpecificEnergyRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SpecificEnergyRow), new FrameworkPropertyMetadata(typeof(SpecificEnergyRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="SpecificVolume"/>
    /// </summary>
    public class SpecificVolumeRow : UnitRow<SpecificVolume, SpecificVolumeUnit>
    {
        static SpecificVolumeRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SpecificVolumeRow), new FrameworkPropertyMetadata(typeof(SpecificVolumeRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Speed"/>
    /// </summary>
    public class SpeedRow : UnitRow<Speed, SpeedUnit>
    {
        static SpeedRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SpeedRow), new FrameworkPropertyMetadata(typeof(SpeedRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Stiffness"/>
    /// </summary>
    public class StiffnessRow : UnitRow<Stiffness, StiffnessUnit>
    {
        static StiffnessRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StiffnessRow), new FrameworkPropertyMetadata(typeof(StiffnessRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Temperature"/>
    /// </summary>
    public class TemperatureRow : UnitRow<Temperature, TemperatureUnit>
    {
        static TemperatureRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TemperatureRow), new FrameworkPropertyMetadata(typeof(TemperatureRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Time"/>
    /// </summary>
    public class TimeRow : UnitRow<Time, TimeUnit>
    {
        static TimeRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimeRow), new FrameworkPropertyMetadata(typeof(TimeRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Torque"/>
    /// </summary>
    public class TorqueRow : UnitRow<Torque, TorqueUnit>
    {
        static TorqueRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TorqueRow), new FrameworkPropertyMetadata(typeof(TorqueRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Unitless"/>
    /// </summary>
    public class UnitlessRow : UnitRow<Unitless, UnitlessUnit>
    {
        static UnitlessRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UnitlessRow), new FrameworkPropertyMetadata(typeof(UnitlessRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Voltage"/>
    /// </summary>
    public class VoltageRow : UnitRow<Voltage, VoltageUnit>
    {
        static VoltageRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VoltageRow), new FrameworkPropertyMetadata(typeof(VoltageRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Volume"/>
    /// </summary>
    public class VolumeRow : UnitRow<Volume, VolumeUnit>
    {
        static VolumeRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VolumeRow), new FrameworkPropertyMetadata(typeof(VolumeRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="VolumetricFlow"/>
    /// </summary>
    public class VolumetricFlowRow : UnitRow<VolumetricFlow, VolumetricFlowUnit>
    {
        static VolumetricFlowRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VolumetricFlowRow), new FrameworkPropertyMetadata(typeof(VolumetricFlowRow)));
        }
    }

    /// <summary>
    /// A <see cref="Row"/> for editing values of type <see cref="Wavenumber"/>
    /// </summary>
    public class WavenumberRow : UnitRow<Wavenumber, WavenumberUnit>
    {
        static WavenumberRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WavenumberRow), new FrameworkPropertyMetadata(typeof(WavenumberRow)));
        }
    }
}
