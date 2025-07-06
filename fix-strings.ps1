# PowerShell script to fix string interpolation in VB.NET files
# Convert C# style ${} to VB.NET style & concatenation

Write-Host "Fixing string interpolation in VB.NET files..."

# Get all .vb files
$vbFiles = Get-ChildItem -Path "." -Filter "*.vb" -Recurse

foreach ($file in $vbFiles) {
    Write-Host "Processing: $($file.FullName)"
    
    $content = Get-Content $file.FullName -Raw
    $originalContent = $content
    
    # Fix common string interpolation patterns
    # Pattern: $"text {variable}" -> "text " & variable
    $content = $content -replace '\$"([^"]*)\{([^}]+)\}([^"]*)"', '"$1" & $2 & "$3"'
    
    # Fix more complex patterns
    $content = $content -replace '\$"([^"]*)\{([^}]+)\}([^"]*)\{([^}]+)\}([^"]*)"', '"$1" & $2 & "$3" & $4 & "$5"'
    
    # Fix simple cases like $"{variable}"
    $content = $content -replace '\$"\{([^}]+)\}"', '$1.ToString()'
    
    # Fix cases with .ToString() calls
    $content = $content -replace '\$"([^"]*)\{([^}]+)\.ToString\(\)\}([^"]*)"', '"$1" & $2.ToString() & "$3"'
    
    # Save if changed
    if ($content -ne $originalContent) {
        Set-Content -Path $file.FullName -Value $content -NoNewline
        Write-Host "  Fixed string interpolation in $($file.Name)"
    }
}

Write-Host "String interpolation fix completed!"
