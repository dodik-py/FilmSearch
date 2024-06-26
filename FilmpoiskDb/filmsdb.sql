PGDMP  
    	                |            films    16.3    16.3     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16398    films    DATABASE     }   CREATE DATABASE films WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Belarusian_Belarus.1251';
    DROP DATABASE films;
                postgres    false                        2615    16399 
   filmscheme    SCHEMA        CREATE SCHEMA filmscheme;
    DROP SCHEMA filmscheme;
                postgres    false            �            1259    16403    actors    TABLE     f   CREATE TABLE filmscheme.actors (
    name text NOT NULL,
    surname text,
    id integer NOT NULL
);
    DROP TABLE filmscheme.actors;
    
   filmscheme         heap    postgres    false    6            �            1259    16425    actors_id_seq    SEQUENCE     �   ALTER TABLE filmscheme.actors ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME filmscheme.actors_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
         
   filmscheme          postgres    false    6    217            �            1259    16400    films    TABLE     K   CREATE TABLE filmscheme.films (
    id integer NOT NULL,
    title text
);
    DROP TABLE filmscheme.films;
    
   filmscheme         heap    postgres    false    6            �            1259    16451    films_id_seq    SEQUENCE     �   ALTER TABLE filmscheme.films ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME filmscheme.films_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
         
   filmscheme          postgres    false    216    6            �            1259    16406    reviews    TABLE     �   CREATE TABLE filmscheme.reviews (
    review text,
    id integer NOT NULL,
    description text,
    stars integer NOT NULL
);
    DROP TABLE filmscheme.reviews;
    
   filmscheme         heap    postgres    false    6            �            1259    16460    reviews_id_seq    SEQUENCE     �   ALTER TABLE filmscheme.reviews ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME filmscheme.reviews_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
         
   filmscheme          postgres    false    218    6            �            1259    16470    reviews_stars_seq    SEQUENCE     �   ALTER TABLE filmscheme.reviews ALTER COLUMN stars ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME filmscheme.reviews_stars_seq
    START WITH 0
    INCREMENT BY 1
    MINVALUE 0
    MAXVALUE 5
    CACHE 1
);
         
   filmscheme          postgres    false    6    218            �            1259    16477    roles    TABLE     h   CREATE TABLE filmscheme.roles (
    id integer NOT NULL,
    films_id integer,
    actors_id integer
);
    DROP TABLE filmscheme.roles;
    
   filmscheme         heap    postgres    false    6            �            1259    16480    roles_id_seq    SEQUENCE     �   ALTER TABLE filmscheme.roles ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME filmscheme.roles_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
         
   filmscheme          postgres    false    6    223            �          0    16403    actors 
   TABLE DATA           7   COPY filmscheme.actors (name, surname, id) FROM stdin;
 
   filmscheme          postgres    false    217   �       �          0    16400    films 
   TABLE DATA           .   COPY filmscheme.films (id, title) FROM stdin;
 
   filmscheme          postgres    false    216          �          0    16406    reviews 
   TABLE DATA           E   COPY filmscheme.reviews (review, id, description, stars) FROM stdin;
 
   filmscheme          postgres    false    218   :       �          0    16477    roles 
   TABLE DATA           <   COPY filmscheme.roles (id, films_id, actors_id) FROM stdin;
 
   filmscheme          postgres    false    223   y       �           0    0    actors_id_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('filmscheme.actors_id_seq', 5, true);
       
   filmscheme          postgres    false    219            �           0    0    films_id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('filmscheme.films_id_seq', 2, true);
       
   filmscheme          postgres    false    220            �           0    0    reviews_id_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('filmscheme.reviews_id_seq', 1, true);
       
   filmscheme          postgres    false    221            �           0    0    reviews_stars_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('filmscheme.reviews_stars_seq', 0, true);
       
   filmscheme          postgres    false    222            �           0    0    roles_id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('filmscheme.roles_id_seq', 1, true);
       
   filmscheme          postgres    false    224            .           2606    16430    actors idactors 
   CONSTRAINT     Q   ALTER TABLE ONLY filmscheme.actors
    ADD CONSTRAINT idactors PRIMARY KEY (id);
 =   ALTER TABLE ONLY filmscheme.actors DROP CONSTRAINT idactors;
    
   filmscheme            postgres    false    217            ,           2606    16469    films idfilm 
   CONSTRAINT     N   ALTER TABLE ONLY filmscheme.films
    ADD CONSTRAINT idfilm PRIMARY KEY (id);
 :   ALTER TABLE ONLY filmscheme.films DROP CONSTRAINT idfilm;
    
   filmscheme            postgres    false    216            0           2606    16467    reviews idreview 
   CONSTRAINT     R   ALTER TABLE ONLY filmscheme.reviews
    ADD CONSTRAINT idreview PRIMARY KEY (id);
 >   ALTER TABLE ONLY filmscheme.reviews DROP CONSTRAINT idreview;
    
   filmscheme            postgres    false    218            2           2606    16485    roles idroles 
   CONSTRAINT     O   ALTER TABLE ONLY filmscheme.roles
    ADD CONSTRAINT idroles PRIMARY KEY (id);
 ;   ALTER TABLE ONLY filmscheme.roles DROP CONSTRAINT idroles;
    
   filmscheme            postgres    false    223            3           2606    16491    roles actors_fk    FK CONSTRAINT     �   ALTER TABLE ONLY filmscheme.roles
    ADD CONSTRAINT actors_fk FOREIGN KEY (actors_id) REFERENCES filmscheme.actors(id) NOT VALID;
 =   ALTER TABLE ONLY filmscheme.roles DROP CONSTRAINT actors_fk;
    
   filmscheme          postgres    false    223    4654    217            4           2606    16486    roles films_fk    FK CONSTRAINT     �   ALTER TABLE ONLY filmscheme.roles
    ADD CONSTRAINT films_fk FOREIGN KEY (films_id) REFERENCES filmscheme.films(id) NOT VALID;
 <   ALTER TABLE ONLY filmscheme.roles DROP CONSTRAINT films_fk;
    
   filmscheme          postgres    false    223    4652    216            �      x�s�+.O-��/N��L�b���� i�/      �      x������ � �      �   /   x�K�V0IS0�HS(JM�/K-�TV(.H��4���4������ ��
9      �      x�3��"�=... EJ     