from rest_framework import serializers
from .models import MachineTrainNotes



class MachineTrainNotesSerializer(serializers.ModelSerializer):
    class Meta:
        model = MachineTrainNotes
        fields = ('pk_machinetrainnoteid', 'machinetrain_note', 'note_date', 'machinetrainnote_isactive', 'fk_machinetrainid', 'machinetrainnote_showonreport', 'analyst_name')

