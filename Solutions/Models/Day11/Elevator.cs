using System.Linq;
using System.Collections.Generic;

namespace Solutions.Models.Day11
{
  public class Elevator
  {
    private const int MaxLoad = 2;

    public List<Generator> Generators { get; set; } = new List<Generator>();

    public List<MicroChip> MicroChips { get; set; } = new List<MicroChip>();

    private int _currentLoad { get; set; }

    public Floor CurrentFloor { get; set; }

    public Floor MoveUp(List<Floor> floors)
    {
      return MoveFloor(true, floors);
    }

    public Floor MoveDown(List<Floor> floors)
    {
      return MoveFloor(false, floors);
    }

    private Floor MoveFloor(bool upDown, List<Floor> floors)
    {
      MapGeneratorTypesToMicroChipTypes();

      MapMicroChipTypesToGeneratorTypes();

      var nextFloor = floors.FirstOrDefault(x => x.FloorNumber == (upDown 
        ? (CurrentFloor.FloorNumber + 1) 
        : (CurrentFloor.FloorNumber - 1))
      );

      if(nextFloor == null)
      {
        if(CurrentFloor.FloorNumber == floors.Max(x => x.FloorNumber))
        {
          //We've reached the topfloor.
          foreach(var generator in Generators)
          {
            RemoveGeneratorFromElevator(generator);
          }

          foreach(var microChip in MicroChips)
          {
            RemoveMicroChipFromElevator(microChip);
          }
        }
        
        return null;
      }
      else
      {
        if(DetermineNextMove(nextFloor))
        {
          CurrentFloor.Elevator = null;
          CurrentFloor = nextFloor;
          nextFloor.Elevator = this;
          return nextFloor;
        }
        else
        {
          return null;
        }        
      }
    }

    private bool DetermineNextMove(Floor nextFloor)
    {
      var hasGenerators = nextFloor.Generators.Any();

      var hasMicroChips = nextFloor.MicroChips.Any();

      if(hasGenerators && !hasMicroChips)
      {
        MapGeneratorTypesToMicroChipTypes();

        //Check if the current floor contains a microchip of the same type as the next floor..
      }
      else if(!hasGenerators && hasMicroChips)
      {
        var microChipTypes = nextFloor.MicroChips.Select(x => x.IsotopeType);

        foreach(var microChipType in microChipTypes)
        {
          var matchingGenerator = CurrentFloor.Generators.FirstOrDefault(x => x.IsotopeType == microChipType);

          if(matchingGenerator != null)
          {
            if(AddGeneratorToElevator(matchingGenerator))
            {
              continue;
            }
          }
        }

        //Check if the current floor contains a generator of the same type.
      }
      else if(!hasGenerators && !hasMicroChips)
      {
        
        //Move a combination of the same generator type and microchip type on the current floor to the next floor. 
      }

      return true;
    }

    private void MapGeneratorTypesToMicroChipTypes()
    {
      foreach(var generatorType in Generators.Select(x => x.IsotopeType))
      {
        var matchingMicroChip = CurrentFloor.MicroChips.FirstOrDefault(x => x.IsotopeType == generatorType);

        if(matchingMicroChip != null)
        {
          if(AddMicroChipToElevator(matchingMicroChip))
          {
            continue;
          }
        }
      }
    }

    private void MapMicroChipTypesToGeneratorTypes()
    {
      foreach(var microChipType in MicroChips.Select(x => x.IsotopeType))
      {
        var matchingGenerator = CurrentFloor.Generators.FirstOrDefault(x => x.IsotopeType == microChipType);

        if(matchingGenerator != null)
        {
          if(AddGeneratorToElevator(matchingGenerator))
          {
            continue;
          }
        }
      }
    }

    private bool RemoveGeneratorFromElevator(Generator generator)
    {
      //We might need to check something here. Check later.

      CurrentFloor.Generators.Add(generator);
      this.Generators.Remove(generator);
      _currentLoad--;
      return true;
    }

    private bool AddGeneratorToElevator(Generator generator)
    {
      if(_currentLoad <= MaxLoad)
      {
        CurrentFloor.Generators.Remove(generator);
        Generators.Add(generator);
        _currentLoad++;
        return true;
      }
      
      return false;
    }

    private bool RemoveMicroChipFromElevator(MicroChip microChip)
    {
      //We might need to check something here. Check later.

      CurrentFloor.MicroChips.Add(microChip);
      this.MicroChips.Remove(microChip);
      _currentLoad--;
      return true;
    }

    private bool AddMicroChipToElevator(MicroChip microChip)
    {
      if(_currentLoad <= MaxLoad)
      {
        CurrentFloor.MicroChips.Remove(microChip);
        MicroChips.Add(microChip);
        _currentLoad++;
        return true;
      }
      
      return false;
    }
  }
}