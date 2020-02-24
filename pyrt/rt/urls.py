from django.urls import path


from . import views

urlpatterns = [
    path('', views.index, name='index'),
    path('machinenotes/<int:machinetrain_id>', views.machinenotes, name='machinenotes'),


    # API
    path('api/machinenotes', views.MachineTrainNotesListCreate.as_view()),
]
