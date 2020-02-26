from django.shortcuts import render, get_object_or_404
from django.http import HttpResponse
from django.template import loader
from .models import MachineTrainNotes, MachineTrain

from .serializers import MachineTrainNotesSerializer
from rest_framework import generics


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


class MachineTrainNotesListCreate(generics.ListAPIView):
    # queryset = MachineTrainNotes.objects.all()
    serializer_class = MachineTrainNotesSerializer

    def get_queryset(self):
        """
        Optionally restricts the returned notes,
        by filtering against a `machinetrainid` query parameter in the URL.
        """
        machinetrainid = self.request.query_params.get('machinetrainid', None)
        if machinetrainid is not None:
            queryset = MachineTrainNotes.objects.all()
            queryset = queryset.filter(fk_machinetrainid=machinetrainid)
            return queryset
        else:
            return []

class MachineTrainNotesDetail(generics.RetrieveAPIView):
    queryset = MachineTrainNotes.objects.all()
    serializer_class = MachineTrainNotesSerializer