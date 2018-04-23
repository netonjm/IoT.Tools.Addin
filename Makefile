#General vars
CONFIG?=Debug
ARGS:=/p:Configuration="${CONFIG}" $(ARGS)

all: submodules
	msbuild IoT.Tools.Addin.sln $(ARGS)

clean:
	find . -type d -name bin -exec rm -rf {} \;
	find . -type d -name obj -exec rm -rf {} \;
	find . -type d -name packages -exec rm -rf {} \;

pack: submodules
	msbuild IoT.Tools.Addin.sln $(ARGS) /p:CreatePackage=true

install:
	msbuild IoT.Tools.Addin.sln $(ARGS) /p:InstallAddin=true

template:
	./install.sh
	rm -rf src/templates/IoT.Tools.Templates.0.0.1.nupkg
	mv IoT.Tools.Templates.0.0.1.nupkg src/templates

nuget-download:
	# nuget restoring
	if [ ! -f nuget.exe ]; then \
	    echo "nuget.exe not found! downloading latest version" ; \
	    curl -O https://dist.nuget.org/win-x86-commandline/latest/nuget.exe ; \
	fi

submodules: nuget-download
	mono ./nuget.exe restore IoT.Tools.Addin.sln

.PHONY: all clean pack install submodules sdk nuget-download
