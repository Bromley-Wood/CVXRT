from django.shortcuts import render, get_object_or_404
from django.http import HttpResponse
from django.template import loader
from .models import MachineTrainNotes, MachineTrain


# Create your views here.

def index(request):
    return HttpResponse("Hello, world. You're at the polls index.")


def machinenotes(request, machinetrain_id):
    machine_info = get_object_or_404(MachineTrain, pk=machinetrain_id)
    machine_notes = MachineTrainNotes.objects.filter(fk_machinetrainid=machinetrain_id)
    context =  {
        'machine_info': machine_info,
        'machine_notes':machine_notes
    }

    return render(request, 'rt/MachineNotes.html', context)
