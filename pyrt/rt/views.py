from django.shortcuts import render
from django.http import HttpResponse
from django.template import loader
from .models import Area

# Create your views here.

def index(request):
    return HttpResponse("Hello, world. You're at the polls index.")


def machinenotes(request, machinetrain_id):
    machine_notes = Area.objects.get(pk=machinetrain_id)
    context=  {
        'machine_notes':[machine_notes]
    }

    return render(request, 'MachineNotes.html', context)
