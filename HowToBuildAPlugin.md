# Introduction #

The following text will describe the process of building a plugin for
the Visual Surveillance System (VSL).
# It is all in the interface #

In order to build a plugin for VSL there is a need to implement one
interface called `ISurveillanceSystem`.
This interface gives all the information needed in order to
configure and use the plugin. When the application loads a plugin from
a dll it looks for this interface.
### Configuration ###

A configuration for a plugin is defined in 4 levels: before runtime
configuration, runtime configuration, runtime information and graphical
display.
#### Before runtime configuration ####

Before runtime configuration controls how the plugin will be
initialized and is defined by two properties:

  1. `IsConfigurable` - If this property returns true it means that the user can configure the surveillance system by clicking "Configure" button on the Configure form.
  1. `ConfigurationForm` - If the above property returns true then you need to implement this property and return a form that allows the user to configure the plugin. Pay attention that the form must inherit from `ConfigurationForm`.

#### Runtime configuration ####

Unlike the previous properties the following 3 properties define how to
configure the plugin during its runtime. If enabled the user can click
"Configure Surveillance System" on the main form and a
configuration form will be displayed.

  1. `IsRuntimeConfigurable` - If this property returns true it means that the user can configure the surveillance system by clicking "Configure Surveillance System" on the main form.
  1. `RuntimeConfigurationForm` - If the above property returns true you need to implement this property and return a form that allows the user to configure the plugin. Pay attention that the form must inherit from `ConfigurationForm`.
  1. `SetRuntimeConfiguration` - Allows you to set the configuration gathered in the runtime configuration form.

#### Runtime information ####

Sometimes you want to give the user the ability to view the inner
mechanism of the surveillance system, the following two properties give
this ability:

  1. `HasRuntimeInformation` - If this property returns true it means that the user can view runtime information by clicking "Show Runtime Information" on the main form.
  1. `RuntimeInformation` - If the above property returns true you need to implement this property and return a form that allows the user to view runtime information.

#### Graphical display ####

Sometimes you do not want to display anything on the screen you want
your plugin just to work behind the scenes on the other hand you can
change the way the plugin displays its results on screen. You
can configure this behavior by using the following two
properties:
  1. `HasGraphicalOutput` - If true the output of the surveillance system will be displayed on screen.
  1. `GraphicalOutput` - Returns a delegate that changes the image that will be displayed on screen.

### The algorithm ###

A surveillance system is not complete without an algorithm that does
the real surveillance. `GetImageProcess`
returns an `IImageProcess`
interface that defines the algorithm. In order to fully understand how
such an algorithm might work you can read an [article](http://www.codeproject.com/KB/audio-video/VisualSLPart1.aspx)
on the subject published in CodeProject.
