using dotnet.podcast.extensions;
using dotnet.podcast.models;

namespace dotnet.podcast.tests.extensions;

public class ProjectExtensionsTests
{
    [Fact]
    public void WithProjectName_Should_Update_ProjectName_When_NewName_Is_Valid()
    {
        // arrange
        var targetNewProjectName = Guid.NewGuid().ToString();
        var oldProjectName = Guid.NewGuid().ToString();
        var project = new Project {ProjectName = oldProjectName };
        
        // act
        project.WithName(targetNewProjectName);
        
        // Assert
        Assert.NotEqual(targetNewProjectName, oldProjectName);
        Assert.NotEqual(project.ProjectName, oldProjectName);
        Assert.Equal(project.ProjectName, targetNewProjectName);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    public void WithProjectName_RaisesArgumentException_When_NewName_Is_Invalid(string newName)
    {
        // arrange
        var oldProjectName = Guid.NewGuid().ToString();
        var project = new Project {ProjectName = oldProjectName };
        
        // act
        var exception = Record.Exception(() => project.WithName(newName));
        
        // Assert
        Assert.NotNull(exception);
        Assert.IsType<ArgumentException>(exception);
    }
    
    [Fact]
    public void WithFiles_Should_Set_FilesToInclude_When_List_Is_Valid()
    {
        // arrange
        var targetFile = Guid.NewGuid().ToString();
        var targetListOfFiles = new List<string>() { targetFile };
        var project = new Project {FilesToInclude = new List<string>()};
        
        // act
        project.WithFiles(targetListOfFiles);
        
        // Assert
        Assert.Equal(targetListOfFiles, project.FilesToInclude);
        Assert.Single(project.FilesToInclude);
        Assert.Equal(targetFile, project.FilesToInclude.First());
    }
    
    [Fact]
    public void WithFiles_RaisesArgumentException_When_List_Is_Invalid()
    {
        // arrange
        List<string> targetListOfFiles = null!;
        var project = new Project {FilesToInclude = new List<string>()};
        
        // act
        var exception = Record.Exception(() => project.WithFiles(targetListOfFiles));
        
        // Assert
        Assert.NotNull(exception);
        Assert.IsType<ArgumentNullException>(exception);
    }
    
    [Fact]
    public void WithTargetArchiveName_Should_Update_TargetArchiveName_When_NewName_Is_Valid()
    {
        // arrange
        var targetArchiveName = Guid.NewGuid().ToString();
        var oldArchiveName = Guid.NewGuid().ToString();
        var project = new Project {TargetArchiveName = oldArchiveName };
        
        // act
        project.WithTargetArchiveName(targetArchiveName);
        
        // Assert
        Assert.NotEqual(targetArchiveName, oldArchiveName);
        Assert.NotEqual(project.TargetArchiveName, oldArchiveName);
        Assert.Equal(project.TargetArchiveName, targetArchiveName);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    public void WithTargetArchiveName_RaisesArgumentException_When_NewName_Is_Invalid(string newName)
    {
        // arrange
        var oldTargetArchiveName = Guid.NewGuid().ToString();
        var project = new Project {TargetArchiveName = oldTargetArchiveName };
        
        // act
        var exception = Record.Exception(() => project.WithName(newName));
        
        // Assert
        Assert.NotNull(exception);
        Assert.IsType<ArgumentException>(exception);
    }
}