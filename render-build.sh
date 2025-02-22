#!/bin/bash
set -eux

# Cài đặt .NET SDK
export DOTNET_ROOT=$HOME/.dotnet
export PATH=$DOTNET_ROOT:$PATH

curl -fsSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel STS
echo "✅ .NET SDK installed successfully."

# Chạy build
dotnet build

