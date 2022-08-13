using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core.Tower.Blocks
{
    public class BlockMovementPathGenerator
    {
        private readonly IEnumerable<IEnumerable<Vector3>> _patterns;
        private int _currentIndex;

        public BlockMovementPathGenerator(IEnumerable<IEnumerable<Vector3>> patterns)
        {
            _patterns = patterns;
        }

        public IEnumerable<Vector3> GetNext(float blockSize, float yHeight)
        {
            var result = ConvertPatternsToPaths(_patterns.ElementAt(_currentIndex), blockSize, yHeight);

            _currentIndex++;
            if (_currentIndex >= _patterns.Count())
                _currentIndex = 0;
            
            return result;
        }

        private IEnumerable<Vector3> ConvertPatternsToPaths(IEnumerable<Vector3> pattern, float blockSize, float yHeight)
        {
            return pattern.Select(patternWaypoint => new Vector3(
                    blockSize * patternWaypoint.x,
                    yHeight, 
                    blockSize * patternWaypoint.z
                    )
                )
                .ToList();
        }
    }
}