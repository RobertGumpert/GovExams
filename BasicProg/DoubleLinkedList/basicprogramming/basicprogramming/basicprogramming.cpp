// basicprogramming.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include "stdlib.h"
#include "string.h"

typedef struct item {
	char * value;
	item *parent;
	item *child;
} ;

typedef item *pItem;

typedef struct list {
	item * head;
	item * tail;
	int size;
} ;

typedef list *pList;

//
//
//

pItem createItem(char *value) {
	pItem newItem = (pItem)malloc(3 * sizeof(pItem));
	newItem->value = value;
	return newItem;
}

int insertAsFirst(char * value, list *l) {
	pItem newItem = createItem(value);
	if (l->head == NULL) {
		l->head = newItem;
		l->tail = newItem;
		return 0;
	}
	l->head = newItem;
	newItem->child = l->head;
	return 0;
}

int insertAsLast(char *value, list *l) {
	pItem newItem = createItem(value);
	if (l->tail == NULL) {
		l->head = newItem;
		l->tail = newItem;
		return 0;
	}
	l->head = newItem;
	newItem->child = l->tail;
	l->tail = newItem;
	return 0;
}

void printList(list *l) {
	pItem next = l->head;
	while (next != NULL)
	{
		//const int OUTPUT_STRING_BUFFER_SIZE = sizeof(next->value);
		//char outputString[OUTPUT_STRING_BUFFER_SIZE + 4];
		if (next->child == NULL) {
			printf("%s -> x\n", next->value);
			break;
		}
		//sprintf_s(outputString, "%s%s", next->value, " -> ");
		printf("%s -> ", next->value);
		next = next->child;
	}
	return;
}

int main()
{
	pList l = (pList)malloc(sizeof(list));
	l->head = NULL;
	l->tail = NULL;
	l->size = 0;
	//
	char s1[] = "Hello";
	char s2[] = "world";
	char s3[] = "My";
	char s4[] = "list";
	char s5[] = "on C!";
	//
	insertAsFirst(s1, l);
	insertAsFirst(s1, l);
	insertAsLast(s3, l);
	insertAsLast(s4, l);
	insertAsLast(s5, l);
	//
	printList(l);
	//
	getchar();
	//
    return 0;
}

