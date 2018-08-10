using Xunit;
using System;
using Riminder.response;
using Newtonsoft.Json;

namespace Riminder.UnitTests.response
{
    public class TrainingMetadata_Test
    {
        private TrainingMetadata _metadata;

        public TrainingMetadata_Test() 
        {
             _metadata = new TrainingMetadata();
        }

        private void resetMetadata()
        {
            _metadata.filter_reference = "reference0";
            _metadata.stage = global::Riminder.RequestConstant.Stage.NEW;
            _metadata.stage_timestamp = 1533805327;
            _metadata.rating = 1;
            _metadata.rating_timestamp = 1533805327;
        }

        [Fact]
        public void Test_isValidOK()
        {
            //Given
            resetMetadata();
            
            //When
            var result = _metadata.is_valid();
            
            //Then
            Assert.True(result, String.Format("This Metadata {0} should be valid.", JsonConvert.SerializeObject(_metadata)));
        }

        [Fact]
        public void Test_isValidBadReference()
        {
            //Given
            resetMetadata();
            _metadata.filter_reference = null;
            
            //When
            var res = _metadata.is_valid();
            
            //Then
            Assert.False(res, String.Format("This Metadata {0} should be invalid.", JsonConvert.SerializeObject(_metadata)));
        }
    }
}