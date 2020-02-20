from django.shortcuts import render
from django.http import HttpResponse

# Create your views here.

def index(request):
    return HttpResponse("Hello, world. You're at the polls index.")


def machinenotes(request, machinetrain_id):
    return HttpResponse(f"Hello, you're at Machine Train {machinetrain_id}")