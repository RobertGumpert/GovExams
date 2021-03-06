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
	newItem->parent = NULL;
	newItem->child = NULL;
	return newItem;
}

int insertAsFirst(char * value, list *l) {
	pItem newItem = createItem(value);
	if (l->head == NULL) {
		l->head = newItem;
		l->tail = newItem;
		return 0;
	}
	l->head->parent = newItem;
	newItem->child = l->head;
	newItem->parent = NULL;
	l->head = newItem;
	l->size++;
	return 0;
}

int insertAsLast(char *value, list *l) {
	pItem newItem = createItem(value);
	if (l->tail == NULL) {
		l->head = newItem;
		l->tail = newItem;
		return 0;
	}
	l->tail->child = newItem;
	newItem->child = NULL;
	newItem->parent = l->tail;
	l->tail = newItem;
	l->size++;
	return 0;
}

int insertByIndex(char *value, int index, list *l) {
	if (index == 0) {
		insertAsFirst(value, l);
		return 0;
	}
	if (index == l->size) {
		insertAsLast(value, l);
		return 0;
	}
	pItem newItem = createItem(value);
	pItem next = l->head;
	int step = 0;
	while (next != NULL)
	{
		if (step + 1 == index) {
			newItem->child = next->child;
			newItem->parent = next;
			next->child->parent = newItem;
			next->child = newItem;
			l->size++;
			break;
		}
		next = next->child;
	}
	return 0;
}

int deleteFirst(list *l) {
	pItem del = l->head;
	l->head->child->parent = NULL;
	l->head = l->head->child;
	free(del);
	l->size--;
	return 0;
}

int deleteLast(list *l) {
	pItem del = l->tail;
	l->tail->parent->child = NULL;
	l->tail = l->tail->parent;
	free(del);
	l->size--;
	return 0;
}

int deleteByIndex(int index, list *l) {
	if (index == 0) {
		deleteFirst(l);
		return 0;
	}
	if (index == l->size) {
		deleteLast(l);
		return 0;
	}
	pItem next = l->head;
	int step = 0;
	while (next != NULL)
	{
		if (step + 1 == index) {
			pItem del = next->child;
			next->child->child->parent = next;
			next->child = next->child->child;
			free(del);
			l->size--;
			break;
		}
		next = next->child;
	}
	return 0;
}

void printList(list *l) {
	pItem next = l->head;
	while (next != NULL)
	{
		if (next->child == NULL) {
			printf("%s -> x; size: %d\n", next->value, l->size);
			break;
		}
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
	l->size = 1;
	//
	char s1[] = "Hello";
	char s2[] = "world";
	char s3[] = "My";
	char s4[] = "list";
	char s5[] = "on C!";
	//
	insertAsLast(s1, l);
	insertAsFirst(s2, l);
	insertAsFirst(s3, l);
	insertAsFirst(s4, l);
	insertAsLast(s5, l);
	printList(l);
	//
	deleteFirst(l);
	printList(l);
	//
	deleteLast(l);
	printList(l);
	//
	deleteByIndex(1, l);
	printList(l);
	//
	insertByIndex(s2, 1, l);
	printList(l);
	//
	getchar();
	//
    return 0;
}

